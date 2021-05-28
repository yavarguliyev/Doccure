import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from './toastr.service';
import { PresenceService } from './presence.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = environment.api;
  private currentUserSource = new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastrService: ToastrService,
    private presenceService: PresenceService
  ) {
    this.currentUser$.pipe(map((user) => console.log(user)));
  }

  public login(email: string, password: string, returnUrl: string) {
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
            this.presenceService.createHubConnection(user);
          }
        })
      )
      .subscribe(() => this.router.navigate([returnUrl]));
  }

  public setCurrentUser(user: User) {
    localStorage.setItem('token', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  public logout() {
    // this.presenceService.stopHubConnection();
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

  public forgetPassword(email: string) {
    return this.http
      .put(`${this.baseUrl}/auth/forget-password`, email)
      .subscribe((response: any) => {
        this.router.navigate(['/auth/login']);
        this.toastrService.success(response.message, 'Success');
      });
  }

  public resetPassword(
    password: string,
    confirmPassword: string,
    token: string
  ) {
    return this.http
      .put(`${this.baseUrl}/auth/reset-password?token=${token}`, {
        password,
        confirmPassword,
      })
      .pipe(
        map((response: any) => {
          if (response.response) {
            this.setCurrentUser(response.response);
            this.toastrService.success(response.message, 'Success');
          }
        })
      )
      .subscribe(() => this.router.navigate(['/main/doctor/dashboard']));
  }

  public checkExistUser(token: string) {
    return this.http.get(`${this.baseUrl}/auth/${token}`).subscribe(() => {});
  }
}
