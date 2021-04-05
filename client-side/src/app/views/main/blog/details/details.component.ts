import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Blog } from 'src/app/shared/models/blog';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html'
})
export class DetailsComponent implements OnInit {
  @Input() blog!: Blog;
  @Input() blogs: Blog[] = [];

  constructor(private route: ActivatedRoute, private main: MainService) { }

  ngOnInit(): void {
    this.apiResponses();
  }

  private apiResponses() {
    const slug: any = this.route.snapshot.paramMap.get('slug');
    this.main
      .getBlog(slug)
      .subscribe((response) => (this.blog = response));
  }
}
