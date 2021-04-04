import { Component, Input, OnInit } from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
})
export class HomepageComponent implements OnInit {
  @Input() setting!: MainPageSettings;

  constructor() {}

  ngOnInit(): void {}
}
