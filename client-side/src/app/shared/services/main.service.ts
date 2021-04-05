import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root',
})
export class MainService {
  private baseUrl = environment.api;

  constructor(private http: HttpClient) {}

  public getBlog(slug: string): Observable<Blog> {
    const url = `${this.baseUrl}/blog/${slug}`;
    return this.http.get<Blog>(url);
  }

  public getBlogList(): Observable<Blog[]> {
    const url = `${this.baseUrl}/blog`;
    return this.http.get<Blog[]>(url);
  }
}
