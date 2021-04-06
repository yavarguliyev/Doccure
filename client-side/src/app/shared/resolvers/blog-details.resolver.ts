import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Blog } from '../models/blog';
import { MainService } from '../services/main.service';

@Injectable({
  providedIn: 'root',
})
export class BlogDetailsResolver implements Resolve<Blog> {
  constructor(private main: MainService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Blog> {
    return this.main.getBlog(route.paramMap.get('slug'));
  }
}
