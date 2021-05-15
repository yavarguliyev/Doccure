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
import { Review, ReviewReplyFormValues } from 'src/app/shared/models/review';
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

    componentRef.instance.submit = this.submit;
    componentRef.instance.id = id;
    componentRef.instance.textContent = this.textContent;
    componentRef.instance.loading = this.loading;
    componentRef.instance.reviewForm = this.reviewForm;

    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    const element: ElementRef[] = this.chooseForms.toArray();
    element.forEach((x) => {
      const elementId: number = parseInt(x.nativeElement.getAttribute('id'));
      if (elementId === id && x.nativeElement.lastElementChild !== domElem) {
        x.nativeElement.appendChild(domElem);
        x.nativeElement.querySelector('.comment-btn').classList.add('d-none');
      }
    });
  }

  public submit(event: Event, reviewId: number) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement.firstElementChild;

    this.loading = true;
    const currentUser: User = JSON.parse(localStorage.getItem('token'));
    if (currentUser && currentUser.role === 'Doctor') {
      const reply: ReviewReplyFormValues = new ReviewReplyFormValues(
        this.textContent,
        reviewId,
        currentUser.id,
        null
      );

      this.reviewService
        .sendReviewReply(reply)
        .then(() => this.reviewForm.reset())
        .finally(() => {
          this.loading = false;

          parent.classList.remove('d-none');
          parent.parentElement.removeChild(
            parent.parentElement.lastElementChild
          );
        });
    }
  }
}
