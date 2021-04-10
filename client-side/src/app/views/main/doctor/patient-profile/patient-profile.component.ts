import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/shared/models/user';
import { DoctorService } from 'src/app/shared/services/doctor.service';

@Component({
  selector: 'app-patient-profile',
  templateUrl: './patient-profile.component.html',
})
export class PatientProfileComponent implements OnInit {
  public patient!: User;

  constructor(
    private route: ActivatedRoute,
    private doctorService: DoctorService,
    private router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit(): void {
    this.apiResponse();
  }

  private apiResponse() {
    const slug: any = this.route.snapshot.paramMap.get('slug');
    this.doctorService.patientBySlug(slug).forEach((response) => (this.patient = response));
  }
}
