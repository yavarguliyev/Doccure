import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { PagesPhotos } from 'src/app/shared/models/pages-images';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent implements OnInit {
  public user!: User;
  @Input() footer!: MainPageSettings;

  @ViewChild('footerAddress', { static: false })
  private footerAddress!: ElementRef;
  @ViewChild('footerDesc', { static: false })
  private footerDesc!: ElementRef;
  public footerPhoto!: PagesPhotos;

  constructor(
    private api: AuthService,
    private changeDetectorRef: ChangeDetectorRef,
    private settingService: SettingsService
  ) {}

  ngOnInit(): void {
    this.apiResponses();
    this.user = this.api.checkUser();
    this.insertHTML();
  }

  private insertHTML() {
    this.changeDetectorRef.detectChanges();

    this.footerAddress?.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.footer.address
    );

    this.footerDesc?.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.footer.footerDesc
    );
  }

  private apiResponses() {
    this.settingService.getPagesPhotots('Footer').subscribe((response) => (this.footerPhoto = response));
  }
}
