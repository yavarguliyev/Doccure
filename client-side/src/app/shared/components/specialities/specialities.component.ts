import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MainPageSettings } from '../../models/main-page-settings';
import { Speciality, SpecialityP } from '../../models/speciality';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-specialities',
  templateUrl: './specialities.component.html',
})
export class SpecialitiesComponent implements OnInit {
  @ViewChild('clinic') clinicSettings!: ElementRef;
  public slideConfig = {slidesToShow: 4, slidesToScroll: 4};

  public specialities: Speciality[] = [];

  constructor(private settings: SettingsService) {}

  ngOnInit(): void {
    this.getSettings();

    const s1 = new SpecialityP(1, 'Urology', 'assets/img/specialities/specialities-01.png');
    const s2 = new SpecialityP(2, 'Neurology', 'assets/img/specialities/specialities-02.png');
    const s3 = new SpecialityP(3, 'Orthopedic', 'assets/img/specialities/specialities-03.png');
    const s4 = new SpecialityP(4, 'Cardiologist', 'assets/img/specialities/specialities-04.png');
    const s5 = new SpecialityP(5, 'Dentist', 'assets/img/specialities/specialities-05.png');

    this.specialities.push(s1);
    this.specialities.push(s2);
    this.specialities.push(s3);
    this.specialities.push(s4);
    this.specialities.push(s5);
  }

  private getSettings() {
    this.settings
      .getMainPageSettings()
      .subscribe((response: MainPageSettings) => {
        this.clinicSettings.nativeElement.insertAdjacentHTML(
          'afterbegin',
          response.clinicAndSpecialitiesTitle
        );

        this.clinicSettings.nativeElement.insertAdjacentHTML(
          'beforeend',
          response.clinicAndSpecialitiesSubTitle
        );
      });
  }
}
