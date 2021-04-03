import { Component, OnInit } from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ConfirmService } from 'src/app/shared/services/confirm.service';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  public show = false;
  public user!: User;
  public footer!: MainPageSettings;

  constructor(
    private api: AuthService,
    private confirm: ConfirmService,
    private settings: SettingsService
  ) {}

  ngOnInit(): void {
    this.getSettings();
    this.checkUser();
  }

  public logout() {
    this.confirm
      .confirm('Confirm logout', 'Do you want to logout?')
      .subscribe((result) => {
        if (result) {
          this.api.logout();
        }
      });
  }

  private checkUser() {
    const userExist: User = this.api.checkUser();
    this.user = userExist;
  }

  public loggedInUser(event: Event) {
    event.preventDefault();
    this.show = !this.show;
  }

  public parentElement(event: Event) {
    event.preventDefault();

    this.parentElementChilds();
  }

  public closeMenu(event: Event) {
    event.preventDefault();

    this.parentElementChilds();
  }

  private parentElementChilds() {
    document.querySelector('html')?.classList.toggle('menu-opened');
    document.querySelector('#main-html-child')?.classList.toggle('opened');
  }

  private getSettings() {
    this.settings
      .getMainPageSettings()
      .subscribe((response: MainPageSettings) => (this.footer = response));
  }
}
