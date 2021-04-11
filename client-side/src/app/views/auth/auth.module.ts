import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthDoctorComponent } from './auth-doctor/auth-doctor.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

@NgModule({
  declarations: [AuthComponent, LoginComponent, ForgetPasswordComponent, ResetPasswordComponent, AuthDoctorComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ComponentsHelperModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AuthModule { }
