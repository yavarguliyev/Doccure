import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { HomepageComponent } from './homepage/homepage.component';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class MainComponent implements OnInit {
  public setting!: MainPageSettings;
  public showFooter = true;

  constructor(private settingService: SettingsService) { }

  ngOnInit(): void {
    this.hideFooter();
    this.apiResponse();
  }

  private hideFooter() {
  }

  private apiResponse() {
    this.settingService
      .getMainPageSettings()
      .forEach((response) => (this.setting = response));
  }

  public onHomePageLoaded(component: HomepageComponent) {
    component.setting = this.setting;
  }
}
