import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Chat, ChatMessageFormValues } from '../models/chat';
import { User } from '../models/user';
import { AuthService } from './auth.service';
import { SpinnerService } from './spinner.service';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private baseUrl = environment.api;
  private hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private messageThreadSource = new BehaviorSubject<Chat[]>([]);
  public messageThread$ = this.messageThreadSource.asObservable();

  constructor(
    private http: HttpClient,
    private spinnerService: SpinnerService,
    private userService: AuthService
  ) {}

  public createHubConnection(user: User) {
    this.spinnerService.busy();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + `chat?token=${user.token}`, {
        accessTokenFactory: () => user.token,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .catch((error) => console.log(error))
      .finally(() => this.spinnerService.idle());

    this.hubConnection.on('ReceiveMessageThread', (messages: Chat[]) => {
      this.messageThreadSource.next(messages);
    });

    this.hubConnection.on('NewMessage', (message: Chat) => {
      this.messageThread$.pipe(take(1)).subscribe((messages: Chat[]) => {
        const index = messages.findIndex((x) => x.id === message.id);
        message.chatMessageDTOs.map((x) => {
          messages[index].chatMessageDTOs.push(x);
        });
        this.messageThreadSource.next(messages);
      });
    });

    this.hubConnection.on(
      'RemoveMessage',
      (chatId: number, messageId: number) => {
        this.messageThread$.pipe(take(1)).subscribe((messages: Chat[]) => {
          messages
            .filter((x) => x.id === chatId)
            .map((x) =>
              x.chatMessageDTOs.forEach((c, i) => {
                if (c.id === messageId) {
                  x.chatMessageDTOs.splice(i, 1);
                }
              })
            );
          this.messageThreadSource.next(messages);
        });
      }
    );

    this.hubConnection.on('RemoveGroup', (chatId: number) => {
      this.messageThread$.pipe(take(1)).subscribe((messages: Chat[]) => {
        messages = messages.filter((x) => x.id !== chatId);
        this.messageThreadSource.next(messages);
      });
    });

    this.hubConnection.on('UpdatedGroup', (groupName) =>
      console.log(`Group ${groupName} updated`)
    );

    this.hubConnection.on('OnlineUsers', (email, connectionId) => {
      console.log(email);
      console.log(connectionId);
    });

    this.hubConnection.on('OfflineUsers', (email, connectionId) => {
      console.log(email);
      console.log(connectionId);
    });
  }

  public stopHubConnection() {
    if (this.hubConnection) {
      this.messageThreadSource.next([]);
      this.hubConnection.stop();
    }
  }

  public getMessages(id: number) {
    return this.http.get<Chat[]>(this.baseUrl + `/chat?id=${id}`);
  }

  public async sendMessage(message: ChatMessageFormValues) {
    return this.hubConnection
      .invoke('SendMessage', message)
      .catch((error) => console.log(error));
  }

  public async removeGroup(chatid: number) {
    return this.hubConnection
      .invoke('RemoveGroup', chatid)
      .catch((error) => console.log(error));
  }

  public async removeMessage(chatid: number, messageId: number) {
    return this.hubConnection
      .invoke('RemoveMessage', chatid, messageId)
      .catch((error) => console.log(error));
  }
}
