import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User, UserFormValues } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthDoctorService {
  private baseUrl = environment.api;

  constructor(private http: HttpClient) { }

  public checkUser(token: string) {
    return this.http.get(`${this.baseUrl}/doctor/${token}`);
  }

  public register(token: string, userForm: UserFormValues) {
    return this.http
      .put<User>(`${this.baseUrl}/doctor?token=${token}`, userForm)
      .pipe(map((user) => user));
  }
}
