import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
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

  public slideConfig = { slidesToShow: 4, slidesToScroll: 4 };

  public specialities: Speciality[] = [];

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

    this.clinicSettings.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.clinicAndSpecialitiesTitle
    );

    this.clinicSettings.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.clinicAndSpecialitiesSubTitle
    );
  }

  private apiResponses() {
    this.settingService
      .getSpeciality()
      .subscribe((response) => (this.specialities = response));
  }
}
