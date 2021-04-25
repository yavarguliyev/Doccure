import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private authService: AuthService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.checkRouter();
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required)
    });
  }

  private checkRouter() {
    const token = this.route.snapshot.paramMap.get('token') as string;
    this.authService.checkExistUser(token);
  }

  public resetPasswordSubmit() {
    const token = this.route.snapshot.paramMap.get('token') as string;
    const password = this.fg.value.password as string;
    const confirmPassword = this.fg.value.confirmPassword as string;

    this.authService.resetPassword(password, confirmPassword, token);
  }
}
