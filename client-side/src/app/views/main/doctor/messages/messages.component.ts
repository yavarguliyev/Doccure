import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { Chat } from 'src/app/shared/models/chat';
import { User } from 'src/app/shared/models/user';
import { ChatService } from 'src/app/shared/services/chat.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
})
export class MessagesComponent implements OnInit {
  @ViewChild('chat_list') chatlist: ElementRef;
  public user: User;
  public chats: Chat[] = [];
  public chat$: Observable<Chat[]>;
  public currentChat: Chat;
  public showChatRight = false;
  public loading = false;
  public role = 0;
  public chatwindow = false;

  constructor(private chatService: ChatService) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.loadMessages();
    this.chat$ = this.chatService.messageThread$;
  }

  private loadHubConnection() {
    if (this.user !== null) {
      this.loading = true;
      this.chatService.createHubConnection(this.user);
    }
  }

  private loadMessages() {
    if (this.user !== null) {
      this.chatService
        .getMessages(this.user.id)
        .subscribe((response: Chat[]) => {
          this.chats = response;
        });
    }
  }

  public closeChatWindow(event: boolean) {
    this.chatwindow = event;
  }

  public showChat(id: number) {
    this.chatService.messageThread$.subscribe((chat: Chat[]) => {
      this.currentChat = Object.values(chat).find((c) => c.patient.id === id);
    });
    this.user = this.currentChat.patient;
    this.role = parseInt(this.user.role, 16);
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
