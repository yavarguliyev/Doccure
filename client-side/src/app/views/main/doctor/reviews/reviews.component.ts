import {
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { Observable } from 'rxjs';
import { DoctorRecommendation } from 'src/app/shared/enums/doctorRecommendation';
import { Review } from 'src/app/shared/models/review';
import { User } from 'src/app/shared/models/user';
import { ReviewService } from 'src/app/shared/services/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
})
export class ReviewsComponent implements OnInit, OnDestroy {
  public user: User;
  public textContent: string;
  public loading = false;
  public reviewThread$: Observable<Review[]>;
  public recommendation: DoctorRecommendation;

  constructor(private reviewService: ReviewService) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.reviewThread$ = this.reviewService.reviewThread$;
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.reviewService.createHubConnection(this.user, this.user.slug);
    }
  }

  ngOnDestroy(): void {
    this.reviewService.stopHubConnection();
  }
}
