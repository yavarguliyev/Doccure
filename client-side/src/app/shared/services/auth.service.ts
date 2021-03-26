import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private http: HttpClient) {}

  public login(email: string, password: string) {
    console.log(email);
    // return this.http.post<User>(`${environment.api}/auth/login`, {
    //   email,
    //   password,
    // }).pipe(map(user => {
    //   console.log(user);
    // }));
  }
}
