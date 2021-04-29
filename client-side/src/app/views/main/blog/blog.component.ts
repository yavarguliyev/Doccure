import { Component, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { PaginatedResult, Pagination } from 'src/app/shared/models/pagination';
import { MainService } from 'src/app/shared/services/main.service';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
})
export class BlogComponent implements OnInit {
  public blogs: Blog[] = [];
  private pageNumber = 1;
  private pageSize = 2;
  private pagination: Pagination;

  constructor(private main: MainService) {}

  ngOnInit(): void {
    this.apiResponse();
  }

  private apiResponse() {
    this.main.getBlogList(this.pageNumber, this.pageSize).subscribe((response: PaginatedResult<Blog[]>) => {
      this.pagination = response.pagination;
      this.blogs = response.result;
    });
  }

  public onBlogListPageLoaded(component: ListComponent) {
    component.blogs = this.blogs;
    component.pagination = this.pagination;
  }

  public onBlogDetailsPageLoaded(component: DetailsComponent) {
    component.blogs = this.blogs;
  }
}
