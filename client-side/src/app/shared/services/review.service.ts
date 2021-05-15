import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review';
import { User } from '../models/user';
import { SpinnerService } from './spinner.service';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
  private baseUrl = environment.api;
  private hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private reviewThreadSource = new BehaviorSubject<Review[]>([]);
  public reviewThread$ = this.reviewThreadSource.asObservable();

  constructor(
    private http: HttpClient,
    private spinnerService: SpinnerService
  ) {}

  public createHubConnection(user: User) {
    this.spinnerService.busy();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + `review?token=${user.token}`, {
        accessTokenFactory: () => user.token,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .catch((error) => console.log(error))
      .finally(() => this.spinnerService.idle());

    this.hubConnection.on('ReceiveReviewThread', (message) => {
      this.reviewThreadSource.next(message);
    });
  }

  public stopHubConnection() {
    if (this.hubConnection) {
      this.reviewThreadSource.next([]);
      this.hubConnection.stop();
    }
  }

  public getReviews(id: number) {
    return this.http.get<Review[]>(this.baseUrl + `/review?id=${id}`);
  }
}
