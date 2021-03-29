import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = environment.api;
  private currentUserSource = new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

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

  setCurrentUser(user: User) {
    localStorage.setItem(`${user.role}`, JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout(user: User) {
    localStorage.removeItem(`${user.role}`);
    this.currentUserSource.next(undefined);
  }
}
