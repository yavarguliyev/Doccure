import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});
  public validationErrors: string[] = [];

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.intitializeForm();
  }

  intitializeForm() {
    this.fg = this.fb.group({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  loginSubmit() {

    console.log(this.fg.value);
  }
}
