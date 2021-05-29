import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PagesPhotos } from 'src/app/shared/models/pages-images';
import { AuthDoctorService } from 'src/app/shared/services/auth-doctor.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-auth-doctor',
  templateUrl: './auth-doctor.component.html',
})
export class AuthDoctorComponent implements OnInit {
  private token!: string;
  public fg: FormGroup = new FormGroup({});
  public loginPhoto: PagesPhotos;

  constructor(
    private authDoctorService: AuthDoctorService,
    private authService: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.checkRouter();
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      fullname: new FormControl('', Validators.required),
      gender: new FormControl('', Validators.required),
      birth: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
    });
  }

  private checkRouter() {
    const token = this.route.snapshot.paramMap.get('token');
    token ? (this.token = token) : (this.token = '');

    this.authService.checkExistUser(this.token);
  }

  public registerSubmit() {
    this.authDoctorService.register(this.token, this.fg.value);
  }
}
