import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { SocialMedia } from 'src/app/shared/models/social-media-settings';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent implements OnInit {
  public user!: User;
  public socialMedia: SocialMedia[] = [];
  public footer!: MainPageSettings;
  @ViewChild('footerAddress') footerAddress!: ElementRef;
  @ViewChild('footerDesc') footerDesc!: ElementRef;

  constructor(private api: AuthService, private settings: SettingsService) {}

  ngOnInit(): void {
    this.getSettings();
    this.user = this.api.checkUser();
  }

  private getSettings() {
    this.settings
      .getMainPageSettings()
      .subscribe((response: MainPageSettings) => {
        this.footer = response;

        this.footerAddress.nativeElement.insertAdjacentHTML(
          'beforeend',
          response.address
        );

        this.footerDesc.nativeElement.insertAdjacentHTML(
          'afterbegin',
          response.footerDesc
        );
      });

    this.settings
      .getSocialMedia()
      .subscribe((response: SocialMedia[]) => (this.socialMedia = response));
  }
}
