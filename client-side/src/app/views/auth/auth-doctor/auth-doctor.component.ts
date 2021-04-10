import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Gender } from 'src/app/shared/enums/gender.enum';
import { AuthDoctorService } from 'src/app/shared/services/auth-doctor.service';
import { ToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-auth-doctor',
  templateUrl: './auth-doctor.component.html',
})
export class AuthDoctorComponent implements OnInit {
  private token!: string;

  public fg: FormGroup = new FormGroup({});
  public maxDate!: Date;
  public gender = Gender;

  constructor(
    private title: Title,
    private authDoctorService: AuthDoctorService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.title.setTitle('Doccure | Doctor Register');
    this.checkRouter();
    this.intitializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
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

    this.authDoctorService.checkUser(this.token).forEach((res) => res);
  }

  public registerSubmit() {
    this.authDoctorService
      .register(this.token, this.fg.value)
      .forEach((response) => this.toastr.success(response.message, 'Success'));
  }
}
