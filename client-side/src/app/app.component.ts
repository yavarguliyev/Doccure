import { Component, OnInit } from '@angular/core';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  private user!: User;
  title = 'Doccure';

  constructor(private auth: AuthService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  private setCurrentUser() {
    this.user = this.auth.checkUser();

    if (this.user) {
      this.auth.setCurrentUser(this.user);
    }
  }
}
