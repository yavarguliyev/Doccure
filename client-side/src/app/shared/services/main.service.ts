import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Blog } from '../models/blog';
import { PaginatedResult } from '../models/pagination';

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

  public getBlogList(
    page: any,
    itemsPerPage: any
  ): Observable<PaginatedResult<Blog[]>> {
    const paginatedResult: PaginatedResult<Blog[]> = new PaginatedResult<
      Blog[]
    >();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http
      .get(`${this.baseUrl}/blog`, { observe: 'response', params })
      .pipe(
        map((response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }

          return paginatedResult;
        })
      );
  }
}
