import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { ToastrService } from './toastr.service';

@Injectable({
  providedIn: 'root',
})
export class PresenceService {
  private hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private onlineUsersSource = new BehaviorSubject<string[]>([]);
  public onlineUsers$ = this.onlineUsersSource.asObservable();

  constructor(private toastr: ToastrService, private router: Router) {}

  public createHubConnection(user: User) {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + `presence?token=${user.token}`, {
        accessTokenFactory: () => user.token,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start().catch((error) => console.log(error));

    this.hubConnection.on('UserIsOnline', (email) => {
      this.onlineUsers$.pipe(take(1)).subscribe((emails) => {
        console.log(email);
        this.onlineUsersSource.next([...emails, email]);
      });
    });

    this.hubConnection.on('UserIsOffline', (email) => {
      this.onlineUsers$.pipe(take(1)).subscribe((emails) => {
        this.onlineUsersSource.next([
          ...emails.filter((x) => x !== email),
        ]);
      });
    });

    this.hubConnection.on('GetOnlineUsers', (emails: string[]) => {
      this.onlineUsersSource.next(emails);
    });

    this.hubConnection.on('NewMessageReceived', ({ doctor, patient }) => {
    });
  }

  public stopHubConnection() {
    this.hubConnection.stop().catch((error) => console.log(error));
  }
}
