import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { Feature } from '../../models/feature';
import { MainPageSettings } from '../../models/main-page-settings';
import { PagesPhotos } from '../../models/pages-images';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-available-features',
  templateUrl: './available-features.component.html',
})
export class AvailableFeaturesComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('available', { static: false })
  private availableSettings!: ElementRef;
  public availablePhoto!: PagesPhotos;

  public options: OwlOptions = {
    loop: true,
    margin: 30,
    nav: false,
    dots: true,
    responsive: {
      0: {
        items: 3
      },
      600: {
        items: 5
      },
      1000: {
        items: 7
      },
      1200: {
        items: 7
      },
      1400: {
        items: 7
      }
    }
  };

  public features: Feature[] = [];

  constructor(
    private settingService: SettingsService,
    private changeDetectorRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.apiResponse();
    this.inserHTML();
  }

  private inserHTML() {
    this.changeDetectorRef.detectChanges();
    this.availableSettings.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.availableTitle
    );

    this.availableSettings.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.availableSubTitle
    );
  }

  private apiResponse() {
    this.settingService
      .getFeature()
      .forEach((response) => (this.features = response));

    this.settingService.getPagesPhotots('Available').forEach((response) => (this.availablePhoto = response));
  }
}
