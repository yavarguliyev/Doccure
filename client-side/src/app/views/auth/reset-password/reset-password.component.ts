import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});
  public validationErrors: string[] = [];

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.intitializeForm();
  }

  intitializeForm() {
    this.fg = this.fb.group({
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required)
    });
  }

  resetPasswordSubmit() {
    console.log(this.fg.value);
  }
}
