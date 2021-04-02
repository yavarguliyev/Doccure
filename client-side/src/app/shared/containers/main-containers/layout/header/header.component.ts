import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ConfirmService } from 'src/app/shared/services/confirm.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  public user!: User;
  public role!: string;

  constructor(private api: AuthService, private confirm: ConfirmService) {}

  ngOnInit(): void {
    this.checkUser();
  }

  public logout(user: string) {
    this.confirm.confirm('Confirm logout', 'Do you want to logout?').subscribe((result) => {
      if (result) {
        this.api.logout(user);
      }
    });
  }

  private checkUser() {
    const userExist: User = this.api.checkUser();
    this.user = userExist;
    this.role = userExist.role;
  }
}
