import { Component, Input, OnInit } from '@angular/core';
import { Blog } from 'src/app/shared/models/blog';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  @Input() blogs: Blog[] = [];

  constructor() {}

  ngOnInit(): void {}
}
