import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { MainPageSettings } from '../../models/main-page-settings';
import { Speciality } from '../../models/speciality';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-specialities',
  templateUrl: './specialities.component.html',
})
export class SpecialitiesComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('clinic', { static: false })
  private clinicSettings!: ElementRef;

  public options: OwlOptions = {
    loop: true,
    margin: 30,
    nav: false,
    dots: true,
    responsive: {
      0: {
        items: 2,
      },
      600: {
        items: 5,
      },
      1000: {
        items: 5,
      },
      1200: {
        items: 7,
      },
      1400: {
        items: 7,
      },
    },
  };

  public specialities: Speciality[] = [];

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

    this.clinicSettings.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.clinicAndSpecialitiesTitle
    );

    this.clinicSettings.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.clinicAndSpecialitiesSubTitle
    );
  }

  private apiResponse() {
    this.settingService
      .getSpeciality()
      .subscribe((response) => (this.specialities = response));
  }
}
