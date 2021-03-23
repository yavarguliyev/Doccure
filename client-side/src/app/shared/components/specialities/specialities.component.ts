import { Component, OnInit } from '@angular/core';
import { Speciality, SpecialityP } from '../../models/speciality';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-specialities',
  templateUrl: './specialities.component.html',
})
export class SpecialitiesComponent implements OnInit {
  specialityOptions: OwlOptions = {
    loop: true,
    margin: 30,
    nav: true,
    dots: false,
    navText: ['<i class="uil uil-angle-left"></i>', '<i class="uil uil-angle-right"></i>'],
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 4
      },
      1000: {
        items: 5
      },
      1200: {
        items: 7
      },
      1400: {
        items: 7
      }
    }
  };

  public specialities: Speciality[] = [];

  constructor() {}

  ngOnInit(): void {
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
}
