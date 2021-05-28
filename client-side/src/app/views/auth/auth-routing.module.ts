import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthDoctorComponent } from './auth-doctor/auth-doctor.component';
import { AuthComponent } from './auth.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent,
        data: { title: 'Auth | Login' },
      },
      {
        path: 'doctor-register/:token',
        component: AuthDoctorComponent,
        data: { title: 'Auth | Doctor Register' },
      },
      {
        path: 'forget-password',
        component: ForgetPasswordComponent,
        data: { title: 'Auth | Forget Password' },
      },
      {
        path: 'reset-password/:token',
        component: ResetPasswordComponent,
        data: { title: 'Auth | Reset Password' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
