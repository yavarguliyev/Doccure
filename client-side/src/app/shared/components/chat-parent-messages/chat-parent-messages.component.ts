import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Observable, timer } from 'rxjs';
import { Chat } from '../../models/chat';
import { User } from '../../models/user';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-chat-parent-messages',
  templateUrl: './chat-parent-messages.component.html',
})
export class ChatParentMessagesComponent implements OnInit, OnDestroy {
  @ViewChild('chat_list') chatlist: ElementRef;
  public user: User;
  public chats: Chat[] = [];
  public chatMessage$: Observable<Chat[]>;
  public currentChat: Chat;
  public showChatRight = false;
  public loading = false;
  public role = 0;
  public chatwindow = false;

  constructor(private chatService: ChatService) {}

  ngOnInit(): void {
    document.querySelector('app-footer').classList.add('d-none');
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.chatMessage$ = this.chatService.messageThread$;
    this.chatService.emailSourceThread$.subscribe((email) => {
      this.chatService.connectionThread$.subscribe((connection) => {
        this.chatService.fullnameThread$.subscribe((fullname) => {
          this.chatMessage$.subscribe((chats) => {
            chats.map((chat) => {
              if (chat.doctor.fullname === fullname) {
                chat.doctor.connectionId = null;
              } else if (chat.patient.fullname === fullname) {
                chat.patient.connectionId = null;
              }
              switch (email) {
                case chat.doctor.email:
                  chat.doctor.connectionId = connection;
                  break;
                case chat.patient.email:
                  chat.patient.connectionId = connection;
                  break;
              }
            });
          });
        });
      });
    });
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.chatService.createHubConnection(this.user);
    }
  }

  public closeChatWindow(event: boolean) {
    this.chatwindow = event;
  }

  public closeWindow(event: boolean) {
    this.chatwindow = event;
    this.showChatRight = event;
  }

  public showChat(id: number) {
    this.chatService.messageThread$.subscribe((chat: Chat[]) => {
      const doctor = Object.values(chat).find((c) => c.doctor.id === id);
      const patient = Object.values(chat).find((c) => c.patient.id === id);
      this.currentChat = doctor ? doctor : patient;
      if (doctor && doctor.doctor !== undefined) {
        this.user = doctor.doctor;
      } else if (patient && patient.patient !== undefined) {
        this.user = patient.patient;
      }
    });

    this.scrollChatMessages();

    if (this.user !== null) {
      timer(100)
        .toPromise()
        .then(() => {
          this.showChatRight = true;
        });
    }
  }

  private scrollChatMessages() {
    this.showChatRight = false;
    window.innerWidth < 800
      ? (this.chatwindow = true)
      : (this.chatwindow = false);
  }

  ngOnDestroy(): void {
    document.querySelector('app-footer').classList.remove('d-none');
    this.chatService.stopHubConnection();
  }
}
