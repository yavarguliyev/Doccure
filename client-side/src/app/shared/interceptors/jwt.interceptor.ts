import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { catchError, take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountService: AuthService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      if (user) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${user.token}`,
          },
        });
      }
    });

    return next.handle(request).pipe(
      catchError((err: Observable<HttpEvent<any>>) => {
        if (err instanceof HttpErrorResponse && err.status === 401) {
          return of(err as any);
        }

        throw err;
      })
    );
  }
}
