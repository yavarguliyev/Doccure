import { Component, Input, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
})
export class HomepageComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  public blogs: Blog[] = [];

  constructor(private main: MainService) {}

  ngOnInit(): void {
    this.apiResponse();
  }

  private apiResponse() {
    this.main.getBlogList().forEach((response) => (this.blogs = response));
  }
}
