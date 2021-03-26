import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-auth-handler',
  templateUrl: './auth-handler.component.html'
})
export class AuthHandlerComponent implements OnInit {
  @Input() authSubmit!: ((formGroup: FormGroup) => void);

  @Input() title: string | undefined;
  @Input() subhead: string | undefined;

  @Input() formGroup!: FormGroup;

  @Input() isLogin = false;
  @Input() isRegister = false;
  @Input() isForgetPassword = false;
  @Input() isResetPassword = false;

  constructor() { }

  ngOnInit(): void { }
}
