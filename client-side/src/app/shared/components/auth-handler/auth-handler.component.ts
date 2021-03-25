import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth-handler',
  templateUrl: './auth-handler.component.html'
})
export class AuthHandlerComponent implements OnInit {
  @Input() isLogin = false;
  @Input() isRegister = false;
  @Input() isForgetPassword = false;
  @Input() isResetPassword = false;

  @Input() fullname = false;
  @Input() email = false;
  @Input() password = false;
  @Input() confirmPassword = false;

  @Input() text: string | undefined;
  @Input() subhead: string | undefined;

  formGroup: FormGroup | undefined;
  validationErrors: string[] = [];

  constructor(private form: FormBuilder) { }

  ngOnInit(): void {
  }

  intitializeForm() {
    this.formGroup = this.form.group({
      fullname: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', [Validators.required]]
    });
  }

}
