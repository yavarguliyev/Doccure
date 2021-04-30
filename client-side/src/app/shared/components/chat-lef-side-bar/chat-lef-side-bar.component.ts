import {
  Component,
  ElementRef,
  EventEmitter,
  OnInit,
  Output,
  QueryList,
  ViewChildren,
} from '@angular/core';

@Component({
  selector: 'app-chat-lef-side-bar',
  templateUrl: './chat-lef-side-bar.component.html',
})
export class ChatLefSideBarComponent implements OnInit {
  @Output() showChatRight = new EventEmitter();
  @ViewChildren('media_chat') mediaChat: QueryList<ElementRef>;

  constructor() {}

  ngOnInit(): void {}

  public show() {
    this.showChatRight.emit(false);
    // const element: ElementRef[] = this.mediaChat.toArray();
    // element.forEach((x) => {
    //   x.nativeElement.classList.toggle('active');
    //   this.showChatRight.emit(false);
    // });
  }
}
