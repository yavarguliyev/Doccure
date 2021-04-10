import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { DoctorService } from 'src/app/shared/services/doctor.service';
import { AppointmentsComponent } from './appointments/appointments.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyPatientsComponent } from './my-patients/my-patients.component';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html'
})
export class DoctorComponent implements OnInit {
  public patients: User[] = [];
  constructor(private doctorService: DoctorService) { }

  ngOnInit(): void {
    this.apiResponse();
  }

  private apiResponse() {
    this.doctorService.patientsAppointment().forEach((response) => (this.patients = response));
  }

  public onDashboardLoaded(component: DashboardComponent) {
    component.patients = this.patients;
  }

  public onAppointmentLoaded(component: AppointmentsComponent) {
    component.patients = this.patients;
  }

  public onMyPatientsLoaded(component: MyPatientsComponent) {
    component.patients = this.patients;
  }
}
