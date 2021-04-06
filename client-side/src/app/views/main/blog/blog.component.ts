import { Component, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { MainService } from 'src/app/shared/services/main.service';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
})
export class BlogComponent implements OnInit {
  public blogs: Blog[] = [];
  private component!: DetailsComponent;

  constructor(private main: MainService) {}

  ngOnInit(): void {
    this.apiResponses();
  }

  private apiResponses() {
    this.main
        .getBlogList()
        .subscribe((response) => (this.blogs = response));
  }

  public onBlogListPageLoaded(component: ListComponent) {
    component.blogs = this.blogs;
  }

  public onBlogDetailsPageLoaded(component: DetailsComponent) {
    component.blogs = this.blogs;
  }
}
