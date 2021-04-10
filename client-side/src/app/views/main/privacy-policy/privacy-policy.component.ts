import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Privacy } from 'src/app/shared/models/privacy';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-privacy-policy',
  templateUrl: './privacy-policy.component.html',
})
export class PrivacyPolicyComponent implements OnInit {
  public privacy: Privacy | undefined;

  constructor(
    private api: SettingsService,
    private title: Title,
  ) {}

  ngOnInit(): void {
    this.title.setTitle('Doccure | Privacy Policy');
    this.getPrivacies();
  }

  private getPrivacies() {
    this.api.getPrivacy().forEach((response) => (this.privacy = response));
  }
}
