import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { Chat } from '../../models/chat';
import { User } from '../../models/user';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-chat-parent-messages',
  templateUrl: './chat-parent-messages.component.html',
})
export class ChatParentMessagesComponent implements OnInit {
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
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.chatMessage$ = this.chatService.messageThread$;
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

  public showChat(id: number) {
    this.chatService.messageThread$.subscribe((chat: Chat[]) => {
      const doctor = Object.values(chat).find((c) => c.doctor.id === id);
      const patient = Object.values(chat).find((c) => c.patient.id === id);
      this.currentChat = doctor ? doctor : patient;
      this.user = doctor ? doctor.doctor : patient.patient;
    });

    this.showChatRight = false;
    window.innerWidth < 800
      ? (this.chatwindow = true)
      : (this.chatwindow = false);

    if (this.user !== null) {
      timer(100)
        .toPromise()
        .then(() => {
          this.showChatRight = true;
        });
    }
  }
}
