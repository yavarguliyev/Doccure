import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-patient-user-tabs',
  templateUrl: './patient-user-tabs.component.html'
})
export class PatientUserTabsComponent implements OnInit {
  @ViewChildren('activeLink') activeLinks!: QueryList<ElementRef>;
  @ViewChildren('patient_profile') patientProfiles!: QueryList<ElementRef>;

  constructor() { }

  ngOnInit(): void {
  }

  public switchNavTabs(event: Event) {
    event.preventDefault();

    const target = event.currentTarget as HTMLElement;
    const href = target.getAttribute('href')?.replace('#', '');
    const navLink: ElementRef[] = this.activeLinks.toArray();
    const patientProfiles: ElementRef[] = this.patientProfiles.toArray();

    patientProfiles.forEach((x) => {
      x.nativeElement.className = 'tab-pane fade';
      if (x.nativeElement.getAttribute('id') === href) {
        x.nativeElement.className = 'tab-pane fade show active';
      }
    });

    navLink.forEach((x) => (x.nativeElement.className = 'nav-link'));

    target.classList.add('active');
  }
}
