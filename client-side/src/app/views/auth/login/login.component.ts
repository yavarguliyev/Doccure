import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PagesPhotos } from 'src/app/shared/models/pages-images';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});
  public returnUrl: string;
  public loginPhoto: PagesPhotos;

  constructor(
    private api: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.api.isExist();
    this.intitializeForm();

    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  public loginSubmit() {
    const email = this.fg.value.email as string;
    const password = this.fg.value.password as string;

    this.api.login(email, password, this.returnUrl);
  }
}
