import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
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

    if (this.user) {
      return true;
    } else if (this.user) {
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
