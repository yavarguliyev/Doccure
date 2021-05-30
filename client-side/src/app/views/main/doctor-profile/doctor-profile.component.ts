import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  QueryList,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { DoctorRecommendation } from 'src/app/shared/enums/doctorRecommendation';
import { Review } from 'src/app/shared/models/review';
import { User } from 'src/app/shared/models/user';
import { ReviewService } from 'src/app/shared/services/review.service';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
})
export class DoctorProfileComponent implements OnInit, OnDestroy {
  private slug: string;
  public user: User;
  public currentDate: Date = new Date();
  public loading = false;
  public reviewThread$: Observable<Review[]>;
  public recommendation: DoctorRecommendation;
  @ViewChild('aboutMeDescription', { static: false })
  private aboutMeDescription: ElementRef;
  @ViewChildren('app') apps!: QueryList<ElementRef>;
  @ViewChildren('activeLink') activeLinks!: QueryList<ElementRef>;

  constructor(
    private route: ActivatedRoute,
    private settingService: SettingsService,
    private changeDetectorRef: ChangeDetectorRef,
    private reviewService: ReviewService
  ) {}

  ngOnInit(): void {
    this.slug = this.route.snapshot.paramMap.get('slug');
    this.settingService.getDoctor(this.slug).subscribe((response) => {
      this.user = response;
      this.inserHTML();
      this.loadHubConnection();
    });
    this.reviewThread$ = this.reviewService.reviewThread$;
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.reviewService.createHubConnection(this.user, this.slug);
    }
  }

  private inserHTML() {
    this.changeDetectorRef.detectChanges();
    this.aboutMeDescription.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.user.biography.substr(0, 250)
    );
  }

  public setApp(event: Event) {
    event.preventDefault();

    const target = event.currentTarget as HTMLElement;
    const href = target.getAttribute('href')?.replace('#', '');
    const navLink: ElementRef[] = this.activeLinks.toArray();
    const app: ElementRef[] = this.apps.toArray();

    app.forEach((x) => {
      x.nativeElement.className = 'tab-pane';
      if (x.nativeElement.getAttribute('id') === href) {
        x.nativeElement.className = 'tab-pane show active';
      }
    });

    navLink.forEach((x) => (x.nativeElement.className = 'nav-link'));

    target.classList.add('active');
  }

  ngOnDestroy(): void {
    this.reviewService.stopHubConnection();
  }
}
