import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Doctor, DoctorD } from '../../models/doctor';
import { MainPageSettings } from '../../models/main-page-settings';

@Component({
  selector: 'app-popular-selection',
  templateUrl: './popular-selection.component.html',
})
export class PopularSelectionComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('popularTitle', { static: false })
  private popularTitle!: ElementRef;
  @ViewChild('popularText', { static: false })
  private popularText!: ElementRef;

  public slideConfig = { slidesToShow: 3, slidesToScroll: 3 };

  public doctors: Doctor[] = [];
  constructor(private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.insertHTML();
    const d1 = new DoctorD(
      1,
      'Ruby Perrin',
      'ruby-perrin',
      'assets/img/doctors/doctor-01.jpg'
    );
    const d2 = new DoctorD(
      2,
      'Darren Elder',
      'darren-elder',
      'assets/img/doctors/doctor-02.jpg'
    );
    const d3 = new DoctorD(
      3,
      'Deborah Angel',
      'deborah-angel',
      'assets/img/doctors/doctor-03.jpg'
    );
    const d4 = new DoctorD(
      4,
      'Sofia Brient',
      'sofia-brient',
      'assets/img/doctors/doctor-04.jpg'
    );
    const d5 = new DoctorD(
      5,
      'Marvin Campbell',
      'marvin-campbell',
      'assets/img/doctors/doctor-05.jpg'
    );
    const d6 = new DoctorD(
      6,
      'Katharine Berthold',
      'katharine-berthold',
      'assets/img/doctors/doctor-06.jpg'
    );
    const d7 = new DoctorD(
      7,
      'Linda Tobin',
      'linda-tobin',
      'assets/img/doctors/doctor-07.jpg'
    );
    const d8 = new DoctorD(
      8,
      'Paul Richard',
      'paul-richard',
      'assets/img/doctors/doctor-08.jpg'
    );

    this.doctors.push(d1);
    this.doctors.push(d2);
    this.doctors.push(d3);
    this.doctors.push(d4);
    this.doctors.push(d5);
    this.doctors.push(d6);
    this.doctors.push(d7);
    this.doctors.push(d8);
  }

  private insertHTML() {
    this.changeDetectorRef.detectChanges();

    this.popularTitle.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.popularTitle,
    );

    this.popularTitle.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.popularSubTitle,
    );

    this.popularText.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.popularText,
    );
  }
}
