import { Component, Input, OnInit } from '@angular/core';
import { Blog } from '../../models/blog';

@Component({
  selector: 'app-blog-sidebar',
  templateUrl: './blog-sidebar.component.html',
})
export class BlogSidebarComponent implements OnInit {
  @Input() blogs: Blog[] = [];

  constructor() {}

  ngOnInit(): void {}
}
