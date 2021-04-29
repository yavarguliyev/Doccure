import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';
import { PaginatedResult, Pagination } from 'src/app/shared/models/pagination';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  @ViewChildren('blog_description') private blogDescription: QueryList<ElementRef>;
  @Input() blogs: Blog[] = [];
  @Input() pagination: Pagination;

  constructor(private mainService: MainService, private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.blogs.forEach(x => this.inserHTML(x));
  }

  public pageChanged(event: any) {
    this.pagination.currentPage = event.page;
    this.loadPage(this.pagination?.currentPage, this.pagination?.itemsPerPage);
  }

  private loadPage(currentPage: any, itemsPerPage: any) {
    this.mainService
      .getBlogList(currentPage, itemsPerPage)
      .subscribe((response: PaginatedResult<Blog[]>) => {
        this.pagination = response.pagination;
        this.blogs = response.result;
        this.blogs.forEach(x => this.inserHTML(x));
      });
  }

  private inserHTML(blog: Blog) {
    this.changeDetectorRef.detectChanges();
    const blogDescription: ElementRef[] = this.blogDescription.toArray();
    blogDescription.forEach(desc => {
      const element = desc.nativeElement as HTMLElement;
      if(blog.slug === element.getAttribute('id')) {
        desc.nativeElement.insertAdjacentHTML(
          'afterbegin',
          blog.description.substr(0, 450)
        );
      }
    });
  }
}
