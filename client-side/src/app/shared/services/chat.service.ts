import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Chat, ChatMessageFormValues } from '../models/chat';
import { Group } from '../models/group';
import { User } from '../models/user';
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
    private spinnerService: SpinnerService
  ) { }

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

    this.hubConnection.on('ReceiveMessageThread', (messages) => {
      this.messageThreadSource.next(messages);
    });

    this.hubConnection.on('NewMessage', (message: Chat) => {
      this.messageThread$.pipe(take(1)).subscribe((messages: Chat[]) => {
        // const index = messages.findIndex(x => x.id === message.id);
        // message.chatMessageDTOs.map(x => {
        //   messages[index].chatMessageDTOs.push(x);
        // });

        console.log(message);
        this.messageThreadSource.next(messages);
      });
    });

    this.hubConnection.on('UpdatedGroup', (group: Group) => {
      console.log(group);
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

  async sendMessage(message: ChatMessageFormValues) {
    return this.hubConnection
      .invoke('SendMessage', message)
      .catch((error) => console.log(error));
  }
}
