import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { DoctorService } from 'src/app/shared/services/doctor.service';
import { ToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
})
export class ChangePasswordComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  constructor(
    private title: Title,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private doctorService: DoctorService
  ) {}

  ngOnInit(): void {
    this.title.setTitle('Doccure | Doctor Change Password');
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      newPassword: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      currentPassword: new FormControl('', Validators.required),
    });
  }

  public updatePassword() {
    this.doctorService
      .updateDoctorPassword(this.fg.value)
      .forEach((response) => this.toastr.success(response, 'Success'));
  }
}
