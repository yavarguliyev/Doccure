import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { UserRole } from 'src/app/shared/enums/userRole.enum';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  public returnUrl!: string;

  constructor(
    private title: Title,
    private router: Router,
    private api: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.api.isExist(UserRole.admin);
    this.api.isExist(UserRole.doctor);
    this.api.isExist(UserRole.patient);
    this.title.setTitle('Gambo | Login');
    this.intitializeForm();

    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  intitializeForm() {
    this.fg = this.fb.group({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  loginSubmit() {
    const email = this.fg.value.email as string;
    const password = this.fg.value.password as string;

    this.api
      .login(email, password)
      .subscribe(() => this.router.navigate([this.returnUrl]));
  }

  logout(role: string) {
    const current = localStorage.getItem(role);
    const user: User = current !== null ? JSON.parse(current) : null;
    this.api.logout(user);
  }
}
