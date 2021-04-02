import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Privacy } from 'src/app/shared/models/privacy';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-privacy-policy',
  templateUrl: './privacy-policy.component.html',
})
export class PrivacyPolicyComponent implements OnInit {
  public privacy: Privacy | undefined;

  constructor(private api: SettingsService, private title: Title, private router: ActivatedRoute) {}

  ngOnInit(): void {
    this.title.setTitle('Doccure | Privacy Policy');
    this.getPrivacies();
  }

  private getPrivacies() {
    this.api.getPrivacy().subscribe({
      next: (response: Privacy) => (this.privacy = response),
      error: (error: Error) => console.error(error),
      complete: () => console.log(),
    });
  }
}
