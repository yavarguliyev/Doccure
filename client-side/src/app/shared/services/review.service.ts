import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {
  Review,
  ReviewReply,
  ReviewReplyFormValues,
  ReviewFormValues,
} from '../models/review';
import { User } from '../models/user';
import { SpinnerService } from './spinner.service';
import { ToastrService } from './toastr.service';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
  private hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private reviewThreadSource = new BehaviorSubject<Review[]>([]);
  public reviewThread$ = this.reviewThreadSource.asObservable();

  constructor(
    private spinnerService: SpinnerService,
    private toastrService: ToastrService
  ) {}

  public createHubConnection(user: User, slug: string) {
    this.spinnerService.busy();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + `review?token=${user.token}&slug=${slug}`, {
        accessTokenFactory: () => user.token,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .catch((error) => this.toastrService.info(error, 'Info'))
      .finally(() => this.spinnerService.idle());

    this.hubConnection.on('ReceiveReviewThread', (reviews) => {
      this.reviewThreadSource.next(reviews);
    });

    this.hubConnection.on('NewReview', (review: Review) => {
      this.reviewThread$.pipe(take(1)).subscribe((reviews: Review[]) => {
        this.reviewThreadSource.next([...reviews, review]);
      });
    });

    this.hubConnection.on('NewReviewReply', (reviewReply: ReviewReply) => {
      this.reviewThread$.pipe(take(1)).subscribe((reviews: Review[]) => {
        reviews
          .filter((x) => x.id === reviewReply.reviewId)
          .map((r) => {
            if (reviewReply) {
              r.isReply = true;
              r.reviewReplyDTOs.unshift(reviewReply);
            }
          });
        this.reviewThreadSource.next(reviews);
      });
    });

    this.hubConnection.on('NewReccomendation', (response: any) => {
      this.reviewThread$.pipe(take(1)).subscribe((reviews: Review[]) => {
        reviews.map((x) => {
          if (x.id === response.id && x.doctorId === response.userId) {
            x.recommendation = response.recommendation;
          }
        });
        this.reviewThreadSource.next(reviews);
      });
    });

    this.hubConnection.on('UpdatedGroup', (groupName) =>
      console.log(`Group ${groupName} updated`)
    );
  }

  public stopHubConnection() {
    if (this.hubConnection) {
      this.reviewThreadSource.next([]);
      this.hubConnection.stop();
    }
  }

  async sendReview(review: ReviewFormValues) {
    return this.hubConnection
      .invoke('SendReview', review)
      .catch((error) => this.toastrService.info(error, 'Info'));
  }

  async sendReccomendation(id: number, userId: number, recommendation: string) {
    return this.hubConnection
      .invoke('SendReccomendation', id, userId, recommendation)
      .catch((error) => this.toastrService.info(error, 'Info'));
  }

  async sendReviewReply(reviewReply: ReviewReplyFormValues) {
    return this.hubConnection
      .invoke('SendReviewReply', reviewReply)
      .catch((error) => this.toastrService.info(error, 'Info'));
  }
}
