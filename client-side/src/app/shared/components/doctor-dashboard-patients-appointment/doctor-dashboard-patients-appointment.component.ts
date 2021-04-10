import { Component, Input, OnInit } from '@angular/core';
import { User } from '../../models/user';

@Component({
  selector: 'app-doctor-dashboard-patients-appointment',
  templateUrl: './doctor-dashboard-patients-appointment.component.html',
})
export class DoctorDashboardPatientsAppointmentComponent implements OnInit {
  @Input() patients: User[] = [];

  constructor() {}

  ngOnInit(): void { }
}
