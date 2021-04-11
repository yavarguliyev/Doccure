import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html'
})
export class ForgetPasswordComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});
  public validationErrors: string[] = [];

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      email: new FormControl('', Validators.required),
    });
  }

  public forgetPasswordSubmit() {
    console.log(this.fg.value);
  }
}
