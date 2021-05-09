import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { Chat, ChatMessage } from '../../models/chat';

@Component({
  selector: 'app-chat-lef-side-bar',
  templateUrl: './chat-lef-side-bar.component.html',
})
export class ChatLefSideBarComponent implements OnInit {
  @ViewChildren('media_chat') mediaChat: QueryList<ElementRef>;
  @Output() showChatRight = new EventEmitter();
  @Input() chats: Chat[] = [];

  constructor() { }

  ngOnInit(): void { }

  public chatMessage(chat: Chat): ChatMessage {
    const chatMessage: ChatMessage = Object.values(chat.chatMessageDTOs).find(x => x.chatId === chat.id && x.isSeen === false);
    return chatMessage;
  }

  public getLastText(chat: Chat): ChatMessage | null {
    const sender = chat.chatMessageDTOs[chat.chatMessageDTOs.length - 1];
    const message = sender.patientContent ? sender : chat.chatMessageDTOs.find(x => x.chatId === chat.id && x.patientContent !== null);
    return message;
  }

  public show(id: number) {
    const element: ElementRef[] = this.mediaChat.toArray();
    element.forEach((x) => x.nativeElement.classList.remove('active'));
    element.forEach((x) => {
      const elementId = parseInt(x.nativeElement.getAttribute('id'));
      if (elementId === id) {
        this.showChatRight.emit(id);
        x.nativeElement.classList.add('active');
      }
    });
  }
}
