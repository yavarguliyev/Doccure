import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserFormValues } from '../models/user';
import { AuthService } from './auth.service';
import { ToastrService } from './toastr.service';

@Injectable({
  providedIn: 'root',
})
export class AuthDoctorService {
  private baseUrl = environment.api;

  constructor(
    private http: HttpClient,
    private toastrService: ToastrService,
    private router: Router,
    private authService: AuthService
  ) {}

  public register(token: string, userForm: UserFormValues) {
    return this.http
      .put(`${this.baseUrl}/doctor?token=${token}`, userForm)
      .pipe(
        map((response: any) => {
          if (response.response) {
            this.authService.setCurrentUser(response.response);
            this.toastrService.success(response.message, 'Success');
          }
        })
      )
      .subscribe(() => this.router.navigate(['/main/doctor/dashboard']));
  }
}
