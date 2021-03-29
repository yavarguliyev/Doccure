import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { ToastrService } from '../services/toastr.service';

@Injectable({
  providedIn: 'root',
})
export class AuthDoctorGuard implements CanActivate {
  constructor(
    private router: Router,
    private auth: AuthService,
    private toastr: ToastrService
  ) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.auth.currentUser$.pipe(
      map((user) => {
        if (user.role.includes('Doctor')) {
          return true;
        }

        console.log(user);
        this.router.navigate(['auth/login'], { queryParams: { returnUrl: state.url } });
        this.toastr.error('You shall not pass!', 'Unauthorized');
        return false;
      })
    );
  }
}
