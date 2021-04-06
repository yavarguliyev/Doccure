import { Component, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  public blogs: Blog[] = [];

  constructor(private main: MainService) {}

  ngOnInit(): void {
    this.apiResponses();
  }

  private apiResponses() {
    this.main
        .getBlogList()
        .subscribe((response) => (this.blogs = response));
  }
}
