import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { PagesPhotos } from 'src/app/shared/models/pages-images';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { AuthDoctorComponent } from './auth-doctor/auth-doctor.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  encapsulation: ViewEncapsulation.ShadowDom,
})
export class AuthComponent implements OnInit {
  public loginPhoto: PagesPhotos;

  constructor(private settingService: SettingsService) {}

  ngOnInit(): void {
    this.apiResponse();
    this.parentElementChilds();
  }

  private apiResponse() {
    this.settingService
      .getPagesPhotots('AdminAndDoctor')
      .subscribe((response) => (this.loginPhoto = response));
  }

  public onLoginPageLoaded(component: LoginComponent) {
    component.loginPhoto = this.loginPhoto;
  }

  public onAuthDoctorPageLoaded(component: AuthDoctorComponent) {
    component.loginPhoto = this.loginPhoto;
  }

  public onForgetPasswordPageLoaded(component: ForgetPasswordComponent) {
    component.loginPhoto = this.loginPhoto;
  }

  public onResetPasswordPageLoaded(component: ResetPasswordComponent) {
    component.loginPhoto = this.loginPhoto;
  }

  private parentElementChilds() {
    document.querySelector('html')?.classList.remove('menu-opened');
    document.querySelector('#main-html-child')?.classList.remove('opened');
  }
}
