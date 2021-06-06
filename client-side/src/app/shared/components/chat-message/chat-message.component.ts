import { Chat } from 'src/app/shared/models/chat';
import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ChatMessage, ChatMessageFormValues } from '../../models/chat';
import { User } from '../../models/user';
import { ChatService } from '../../services/chat.service';
import { ConfirmService } from '../../services/confirm.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { timer } from 'rxjs';

@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
})
export class ChatMessageComponent implements OnInit {
  private baseUrl = environment.api;
  @ViewChild('chat_list') chatlist: ElementRef;
  @ViewChild('messageForm') messageForm: NgForm;
  @Output() submitChatWindow = new EventEmitter();
  @Output() closeChatWindow = new EventEmitter();
  public messageContent: string;
  public loading = false;
  @Input() show = false;
  @Input() user: User;
  @Input() chatId: number;
  public messages: ChatMessage[] = [];

  @Input() chat: Chat;

  public uploader: FileUploader;

  constructor(
    private chatService: ChatService,
    private confirmService: ConfirmService
  ) {}

  ngOnInit(): void {
    this.initializeUploader();
  }

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
        null,
        null
      );

      if (currentUser.role === 'Doctor') {
        message.doctorContent = this.messageContent;
      } else if (currentUser.role === 'Patient') {
        message.patientContent = this.messageContent;
      }

      if (this.uploader.queue.length > 0) {
        this.uploader.uploadAll();
        this.uploader.onSuccessItem = (response: any, status) => {
          if (response && response._xhr.response) {
            const res = JSON.parse(response._xhr.response);
            message.photo = res.publicId;
            message.photoURL = res.url;
            this.messageSent(message);
            return;
          }
        };
      } else {
        this.messageSent(message);
        return;
      }
    }
  }

  public removeMessage(id: number) {
    this.confirmService
      .confirm(
        'Confirm removing the message',
        'Do you want to remove the message?'
      )
      .subscribe((result) => {
        if (result) {
          this.chatService.removeMessage(this.chat.id, id);
        }
      });
  }

  public removeChat(id: number) {
    this.confirmService
      .confirm('Confirm removing the group', 'Do you want to remove the group?')
      .subscribe((result) => {
        if (result) {
          this.closeChatWindow.emit(false);
          this.chatService.removeGroup(id);
        }
      });
  }

  private initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + '/chat',
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };
  }

  private messageSent(message: ChatMessageFormValues) {
    this.chatService
      .sendMessage(message)
      .then(() => this.messageForm.reset())
      .finally(() => (this.loading = false));
  }
}
