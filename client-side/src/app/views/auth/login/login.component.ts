import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});
  public validationErrors: string[] = [];

  public returnUrl!: string;

  constructor(
    private title: Title,
    private api: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
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

  loginSubmit(formGroup: FormGroup) {
    const email = formGroup.value.email as string;
    const password = formGroup.value.password as string;

    this.api.login(email, password);
  }
}
