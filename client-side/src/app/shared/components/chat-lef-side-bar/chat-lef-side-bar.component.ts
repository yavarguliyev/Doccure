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
  @ViewChildren('media_chat') mediaChat: QueryList<ElementRef>;
  @Output() showChatRight = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}

  public show(id: number) {
    const element: ElementRef[] = this.mediaChat.toArray();
    element.forEach(x => x.nativeElement.classList.remove('active'));
    element.forEach((x) => {
      const elementId = parseInt(x.nativeElement.getAttribute('id'));
      if(elementId === id) {
        this.showChatRight.emit(id);
        x.nativeElement.classList.add('active');
      }
    });
  }
}
