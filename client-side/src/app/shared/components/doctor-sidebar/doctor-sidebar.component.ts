import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { AuthService } from '../../services/auth.service';
import { ConfirmService } from '../../services/confirm.service';

@Component({
  selector: 'app-doctor-sidebar',
  templateUrl: './doctor-sidebar.component.html',
})
export class DoctorSidebarComponent implements OnInit {
  public user!: User;
  constructor(
    private userService: AuthService,
    private confirm: ConfirmService
  ) {}

  ngOnInit(): void {
    this.currentUser();
  }

  private currentUser() {
    this.userService.currentUser$.subscribe((response) => (this.user = response));
  }

  public logout() {
    this.confirm
      .confirm('Confirm logout', 'Do you want to logout?')
      .subscribe((result) => {
        if (result) {
          this.userService.logout();
        }
      });
  }
}
