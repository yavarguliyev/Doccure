import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-breadcrumb',
  templateUrl: './main-breadcrumb.component.html'
})
export class MainBreadcrumbComponent implements OnInit {
  @Input() title: string | undefined;
  @Input() isSearch = false;

  constructor() { }

  ngOnInit(): void {
  }

}
