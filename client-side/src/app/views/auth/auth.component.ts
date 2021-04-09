import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AuthComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.parentElementChilds();
  }

  private parentElementChilds() {
    document.querySelector('html')?.classList.remove('menu-opened');
    document.querySelector('#main-html-child')?.classList.remove('opened');
  }
}
