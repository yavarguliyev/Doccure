import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Blog } from 'src/app/shared/models/blog';
import { Comment } from 'src/app/shared/models/comment';
import { User } from 'src/app/shared/models/user';
import { CommentService } from 'src/app/shared/services/comment.service';
import { MainService } from 'src/app/shared/services/main.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
})
export class DetailsComponent implements OnInit, OnDestroy {
  public blog!: Blog;
  public user: User;
  @Input() blogs: Blog[] = [];
  public slug: string;
  public loading = false;
  public commentThread$: Observable<Comment[]>;

  constructor(
    private route: ActivatedRoute,
    private main: MainService,
    private router: Router,
    private commentService: CommentService
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit(): void {
    const user: User = JSON.parse(localStorage.getItem('token'));
    if (user) {
      this.user = user;
    }
    this.apiResponse();
    this.loadHubConnection();
    this.commentThread$ = this.commentService.commentThread$;
  }

  private apiResponse() {
    this.slug = this.route.snapshot.paramMap.get('slug');
    this.main.getBlog(this.slug).forEach((response) => (this.blog = response));
  }

  private loadHubConnection() {
    if (this.slug !== null) {
      this.loading = true;
      this.commentService.createHubConnection(this.slug);
    }
  }

  ngOnDestroy(): void {
    this.commentService.stopHubConnection();
  }
}
