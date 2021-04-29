import { Component, Input, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { PaginatedResult } from 'src/app/shared/models/pagination';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
})
export class HomepageComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  public blogs: Blog[] = [];
  private pageNumber = 1;
  private pageSize = 4;

  constructor(private main: MainService) {}

  ngOnInit(): void {
    this.apiResponse();
  }

  private apiResponse() {
    this.main.getBlogList(this.pageNumber, this.pageSize).subscribe((response: PaginatedResult<Blog[]>) => {
      this.blogs = response.result;
    });
  }
}
