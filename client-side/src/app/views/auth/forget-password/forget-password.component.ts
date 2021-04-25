import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html'
})
export class ForgetPasswordComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      email: new FormControl('', Validators.required),
    });
  }

  public forgetPasswordSubmit() {
    this.authService.forgetPassword(this.fg.value);
  }
}
