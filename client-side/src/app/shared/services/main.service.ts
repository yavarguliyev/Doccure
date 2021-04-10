import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root',
})
export class MainService {
  private baseUrl = environment.api;
  private memberCache = new Map();

  constructor(private http: HttpClient) {}

  public getBlog(slug: any): Observable<Blog> {
    const blog = [...this.memberCache.values()]
                .reduce((arr, elem) => arr.concat(elem.result), [])
                .find((x: Blog) => x.slug === slug);

    if (blog) {
      return of(blog);
    }

    const url = `${this.baseUrl}/blog/${slug}`;
    return this.http.get<Blog>(url);
  }

  public getBlogList(): Observable<Blog[]> {
    const url = `${this.baseUrl}/blog`;
    return this.http.get<Blog[]>(url);
  }
}
