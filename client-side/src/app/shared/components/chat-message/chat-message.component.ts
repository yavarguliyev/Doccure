import { Chat } from 'src/app/shared/models/chat';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ChatMessage, ChatMessageFormValues } from '../../models/chat';
import { User } from '../../models/user';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
})
export class ChatMessageComponent implements OnInit {
  @ViewChild('chat_list') chatlist: ElementRef;
  @ViewChild('messageForm') messageForm: NgForm;
  @Output() submitChatWindow = new EventEmitter();
  public messageContent: string;
  public loading = false;
  @Input() show = false;
  @Input() user: User;
  @Input() chatId: number;
  public messages: ChatMessage[] = [];

  @Input() chat: Chat;
  @Input() role = 0;

  constructor(private chatService: ChatService) {}

  ngOnInit(): void {}

  public scrollDown(): ElementRef {
    this.chatlist.nativeElement.lastElementChild.scrollIntoView({
      behavior: 'smooth',
      block: 'end',
      inline: 'nearest',
    });
    return this.chatlist;
  }

  public chatGoBack() {
    this.submitChatWindow.emit(false);
  }

  public sendMessage() {
    this.loading = true;
    const currentUser: User = JSON.parse(localStorage.getItem('token'));
    if (currentUser) {
      const message: ChatMessageFormValues = new ChatMessageFormValues(
        this.chatId,
        this.user.id,
        null,
        null,
        null
      );

      if (currentUser.role === 'Doctor') {
        message.doctorContent = this.messageContent;
      } else if (currentUser.role === 'Patient') {
        message.patientContent = this.messageContent;
      }

      this.chatService
        .sendMessage(message)
        .then(() => this.messageForm.reset())
        .finally(() => (this.loading = false));
    }
  }
}
