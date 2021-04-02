import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { Observable, ReplaySubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = environment.api;
  private currentUserSource = new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {
    this.currentUser$.pipe(map((user) => console.log(user)));
  }

  public login(email: string, password: string) {
    return this.http
      .post<User>(`${this.baseUrl}/auth/login`, {
        email,
        password,
      })
      .pipe(
        map((response: User) => {
          const user = response;
          if (user) {
            this.setCurrentUser(user);
          }
        })
      );
  }

  public setCurrentUser(user: User) {
    localStorage.setItem('token', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  public logout(user: string) {
    localStorage.removeItem('token');
    this.currentUserSource.next(undefined);
    this.router.navigate(['/auth/login']);
  }

  public isExist() {
    const currentUser = localStorage.getItem('token');
    if (currentUser) {
      this.router.navigate(['/']);
    }
  }

  public checkUser() {
    const currentUser = localStorage.getItem('token');
    if (currentUser) {
      const userExist = currentUser !== null ? JSON.parse(currentUser) : null;
      return userExist;
    }
  }
}
