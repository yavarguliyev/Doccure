import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
})
export class MessagesComponent implements OnInit {
  @ViewChild('chat_list') chatlist: ElementRef;
  public showChatRight = false;

  constructor() {}

  ngOnInit(): void {}

  public showChat() {
    this.showChatRight = true;
  }
}
