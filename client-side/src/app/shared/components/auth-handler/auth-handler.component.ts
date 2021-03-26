import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-auth-handler',
  templateUrl: './auth-handler.component.html'
})
export class AuthHandlerComponent implements OnInit {
  @Input() submit: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();

  @Input() title: string | undefined;
  @Input() subhead: string | undefined;

  @Input() formGroup!: FormGroup;

  @Input() isLogin = false;
  @Input() isRegister = false;
  @Input() isForgetPassword = false;
  @Input() isResetPassword = false;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submit.emit(this.formGroup);
    console.log(this.formGroup);
  }
}
