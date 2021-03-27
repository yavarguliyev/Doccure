import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User, UserFormValues } from '../models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  public checkUser(token: string) {
    return this.http.get(`${environment.api}/doctor/${token}`);
  }

  public login(email: string, password: string) {
    return this.http
      .post<User>(`${environment.api}/auth/login`, {
        email,
        password,
      })
      .pipe(map((user) => user));
  }

  public register(token: string, userForm: UserFormValues) {
    return this.http
      .put<User>(`${environment.api}/doctor?token=${token}`, userForm)
      .pipe(map((user) => user));
  }
}
