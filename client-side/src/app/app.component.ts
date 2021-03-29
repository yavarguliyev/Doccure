import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'Doccure';

  constructor(private auth: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const current = localStorage.getItem('Doctor');
    const user: User = current !== null ? JSON.parse(current) : null;
    if (user) {
      this.auth.setCurrentUser(user);
    }
  }
}
