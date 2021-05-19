import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Comment, CommentFormValues, CommentReply, CommentReplyFormValues } from '../models/comment';
import { SpinnerService } from './spinner.service';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  private hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private commentThreadSource = new BehaviorSubject<Comment[]>([]);
  public commentThread$ = this.commentThreadSource.asObservable();

  constructor(private spinnerService: SpinnerService) {}

  public createHubConnection(slug: string) {
    this.spinnerService.busy();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + `comment?slug=${slug}`)
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .catch((error) => console.log(error))
      .finally(() => this.spinnerService.idle());

    this.hubConnection.on('ReceiveCommentThread', (comments: Comment[]) => {
      this.commentThreadSource.next(comments);
    });

    this.hubConnection.on('NewComment', (comment: Comment) => {
      this.commentThread$.pipe(take(1)).subscribe((comments: Comment[]) => {
        comments.unshift(comment);
        this.commentThreadSource.next(comments);
      });
    });

    this.hubConnection.on('NewCommentReply', (commentReply: CommentReply) => {
      this.commentThread$.pipe(take(1)).subscribe((comments: Comment[]) => {
        comments.filter(x => x.id === commentReply.commentId).map(x => {
          if (commentReply) {
            x.isReply = true;
            x.commentReplyDTOs.unshift(commentReply)
          }
        });
        this.commentThreadSource.next(comments);
      });
    });
  }

  public stopHubConnection() {
    if (this.hubConnection) {
      this.commentThreadSource.next([]);
      this.hubConnection.stop();
    }
  }

  async sendComment(comment: CommentFormValues) {
    return this.hubConnection
      .invoke('SendComment', comment)
      .catch((error) => console.log(error));
  }

  async sendCommentReply(reply: CommentReplyFormValues) {
    return this.hubConnection
      .invoke('SendCommentReply', reply)
      .catch((error) => console.log(error));
  }
}
