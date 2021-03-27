import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from 'src/app/shared/enums/gender.enum';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ToastrService } from 'src/app/shared/services/toastr.service';
import { EnumType } from 'typescript';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {
  private token!: string;

  public fg: FormGroup = new FormGroup({});
  public maxDate!: Date;
  public gender = Gender;

  constructor(
    private title: Title,
    private api: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.title.setTitle('Doccure | Register');
    this.checkRouter();
    this.intitializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  intitializeForm() {
    this.fg = this.fb.group({
      fullname: new FormControl('', Validators.required),
      gender: new FormControl('', Validators.required),
      birth: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
    });
  }

  checkRouter() {
    const token = this.route.snapshot.paramMap.get('token');
    token ? (this.token = token) : (this.token = '');

    this.api.checkUser(this.token).subscribe(
      () => {},
      (error) => {
        if (error.status === 404) {
          this.router.navigate(['/errors/not-found']);
        }
      }
    );
  }

  registerSubmit() {
    this.api.register(this.token, this.fg.value).subscribe(
      (response) => {
        console.log(response);
        this.toastr.success(response.message, 'Success');
      },
      (error) => {
        this.toastr.warning('Error', 'User');
      }
    );
  }
}
