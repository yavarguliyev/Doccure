import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Gender } from '../../enums/gender.enum';

@Component({
  selector: 'app-auth-auth',
  templateUrl: './auth-auth.component.html',
})
export class AuthAuthComponent implements OnInit {
  @Input() fg: FormGroup = new FormGroup({});
  @Input() returnUrl!: string;
  @Input() title!: string;
  @Input() subTitle!: string;
  @Input() isLogin = false;
  @Input() isRegister = false;
  @Input() isForget = false;
  @Input() isReset = false;
  @Output() submitForm = new EventEmitter();

  public maxDate!: Date;
  public gender = Gender;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  public submit() {
    this.submitForm.emit();
  }
}
