import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Feature } from '../../models/feature';
import { MainPageSettings } from '../../models/main-page-settings';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-available-features',
  templateUrl: './available-features.component.html',
})
export class AvailableFeaturesComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('available', { static: false })
  private availableSettings!: ElementRef;

  public slideConfig = { slidesToShow: 4, slidesToScroll: 4 };

  public features: Feature[] = [];

  constructor(
    private settingService: SettingsService,
    private changeDetectorRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.apiResponses();
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

  private apiResponses() {
    this.settingService
      .getFeature()
      .subscribe((response) => (this.features = response));
  }
}
