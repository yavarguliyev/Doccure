import {
  ApplicationRef,
  Component,
  ComponentFactoryResolver,
  ElementRef,
  EmbeddedViewRef,
  Injector,
  OnInit,
  QueryList,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ReviewFormComponent } from 'src/app/shared/components/review-form/review-form.component';
import { DoctorRecommendation } from 'src/app/shared/enums/doctorRecommendation';
import { Review } from 'src/app/shared/models/review';
import { User } from 'src/app/shared/models/user';
import { ReviewService } from 'src/app/shared/services/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
})
export class ReviewsComponent implements OnInit {
  @ViewChild('reviewForm') reviewForm: NgForm;
  @ViewChildren('choosenForm') chooseForms: QueryList<ElementRef>;
  public user: User;
  public textContent: string;
  public loading = false;
  public reviewThread$: Observable<Review[]>;
  public recommendation: DoctorRecommendation;

  constructor(
    private reviewService: ReviewService,
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector,
    private appRef: ApplicationRef
  ) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.reviewThread$ = this.reviewService.reviewThread$;
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.reviewService.createHubConnection(this.user);
    }
  }

  public addReplyText(id: number) {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(ReviewFormComponent)
      .create(this.injector);

    componentRef.instance.id = id;
    componentRef.instance.textContent = this.textContent;
    componentRef.instance.loading = this.loading;
    componentRef.instance.reviewForm = this.reviewForm;

    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    const element: ElementRef[] = this.chooseForms.toArray();
    element.forEach((x) => {
      const elementId: number = parseInt(x.nativeElement.getAttribute('id'), 16);
      if (elementId === id && x.nativeElement.lastElementChild !== domElem) {
        x.nativeElement.appendChild(domElem);
        x.nativeElement.querySelector('.comment-btn').classList.add('d-none');
      }
    });
  }

  public sendRecommendation(id: number, userId: number, recommendation: DoctorRecommendation) {
    this.reviewService.sendReccomendation(id, userId, recommendation);
  }
}
