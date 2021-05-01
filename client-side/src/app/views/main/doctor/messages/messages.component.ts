import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Chat, ChatMessage } from 'src/app/shared/models/chat';
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
  public showChatRight = false;
  public loading = false;

  constructor(private chatService: ChatService) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('token'));
    this.loadHubConnection();
    this.loadMessages();
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

  public showChat(id: number) {
    const chat: Chat = Object.values(this.chats).find(x => x.patient.id === id);
    this.user = chat.patient ? chat.patient : null;
    if (this.user !== null) {
      this.showChatRight = true;
    }
  }
}
