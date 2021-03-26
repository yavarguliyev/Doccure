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
import { ToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  public returnUrl!: string;

  constructor(
    private title: Title,
    private api: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService
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

  loginSubmit() {
    const email = this.fg.value.email as string;
    const password = this.fg.value.password as string;

    this.api.login(email, password).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        this.toastr.warning(error.error.errors.user, 'User');
        console.log(error.error.errors.user);
      }
    );
  }
}
