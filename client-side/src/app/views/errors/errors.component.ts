import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-errors',
  templateUrl: './errors.component.html',
  styleUrls: ['./errors.component.scss'],
  encapsulation: ViewEncapsulation.ShadowDom,
})
export class ErrorsComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
