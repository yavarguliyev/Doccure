import {
  ApplicationRef,
  Component,
  ComponentFactoryResolver,
  ElementRef,
  EmbeddedViewRef,
  Injector,
  OnInit,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { Observable } from 'rxjs';
import { ReviewFormComponent } from 'src/app/shared/components/review-form/review-form.component';
import { Review } from 'src/app/shared/models/review';
import { User } from 'src/app/shared/models/user';
import { ReviewService } from 'src/app/shared/services/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
})
export class ReviewsComponent implements OnInit {
  @ViewChildren('choosenForm') chooseForms: QueryList<ElementRef>;
  public user: User;
  public loading = false;
  public reviews: Review[] = [];
  public reviewThread$: Observable<Review[]>;

  constructor(
    private reviewService: ReviewService,
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector,
    private appRef: ApplicationRef
  ) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.loadReviews();
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.reviewService.createHubConnection(this.user);
    }
  }

  private loadReviews() {
    if (this.user !== null) {
      this.reviewService
        .getReviews(this.user.id)
        .subscribe((response: Review[]) => {
          this.reviews = response;
          this.reviewThread$ = this.reviewService.reviewThread$;
        });
    }
  }

  public addReplyText(id: number) {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(ReviewFormComponent)
      .create(this.injector);

    componentRef.instance.submit = this.submit;
    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    const element: ElementRef[] = this.chooseForms.toArray();
    element.forEach(x => {
      const elementId: number = parseInt(x.nativeElement.getAttribute('id'));
      if (elementId === id && x.nativeElement.lastElementChild !== domElem) {
        x.nativeElement.appendChild(domElem);
        x.nativeElement.querySelector('.comment-btn').classList.add('d-none');
      }
    });
  }

  public submit(event: Event) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement.firstElementChild;
    parent.classList.remove('d-none');
    parent.parentElement.removeChild(parent.parentElement.lastElementChild);
  }
}
