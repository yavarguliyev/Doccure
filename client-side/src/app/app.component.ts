import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRole } from './shared/enums/userRole.enum';
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
    const admin = localStorage.getItem('Admin');
    const doctor = localStorage.getItem('Doctor');
    const patient = localStorage.getItem('Patient');

    if (admin) {
      this.user = admin !== null ? JSON.parse(admin) : null;
    } else if (doctor) {
      this.user = doctor !== null ? JSON.parse(doctor) : null;
    } else if (patient) {
      this.user = patient !== null ? JSON.parse(patient) : null;
    }

    if (this.user) {
      this.auth.setCurrentUser(this.user);
    }
  }
}
