import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { UserRole } from '../enums/userRole.enum';
import { User } from '../models/user';
import { AuthService } from '../services/auth.service';
import { ToastrService } from '../services/toastr.service';

@Injectable({
  providedIn: 'root',
})
export class AuthDoctorGuard implements CanActivate {
  private user!: User;
  constructor(
    private router: Router,
    private auth: AuthService,
    private toastr: ToastrService
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    this.auth.currentUser$.subscribe((user) => (this.user = user));

    if (this.user && this.user.role === UserRole.doctor) {
      return true;
    } else if (this.user && this.user.role !== UserRole.doctor) {
      this.router.navigate(['/']);
      this.toastr.error('You shall not pass!', 'Authorized');
      return false;
    } else {
      this.router.navigate(['auth/login'], {
        queryParams: { returnUrl: state.url },
      });
      return false;
    }
  }
}
