import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  private user!: User;
  title = 'Doccure';

  constructor(private auth: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    this.checkUser('Admin');
    this.checkUser('Doctor');
    this.checkUser('Patient');

    if (this.user) {
      this.auth.setCurrentUser(this.user);
    }
  }

  checkUser(user: string) {
    const currentUser = localStorage.getItem(user);
    if (currentUser) {
      this.user = currentUser !== null ? JSON.parse(currentUser) : null;
    }
  }
}
