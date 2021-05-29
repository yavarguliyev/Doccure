import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Gender } from '../../enums/gender.enum';
import { PagesPhotos } from '../../models/pages-images';

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
  @Input() loginPhoto: PagesPhotos;

  public maxDate!: Date;
  public gender = Gender;

  constructor() { }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  public submit() {
    this.submitForm.emit();
  }
}
