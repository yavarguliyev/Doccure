import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Observable, timer } from 'rxjs';
import { Chat } from '../../models/chat';
import { Connection } from '../../models/connection';
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
    this.chatService.connectionThread$.subscribe(
      (connections: Connection[]) => {
        if (connections && typeof connections.map === 'function') {
          connections.map((connection) => {
            this.chatMessage$.subscribe((chats) => {
              chats.map((chat) => {
                switch (connection.email) {
                  case chat.doctor.email:
                    chat.doctor.connectionId = connection.connectionId;
                    break;
                  case chat.patient.email:
                      chat.patient.connectionId = connection.connectionId;
                      break;
                  default:
                    if (chat.patient.fullname === connection.fullname) {
                      chat.patient = null;
                    } else if (chat.doctor.fullname === connection.fullname) {
                      chat.doctor = null;
                    }
                    break;
                }
              });
            });
          });
        }
      }
    );
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
