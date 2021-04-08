import { Component, OnInit } from '@angular/core';
import { AppointmentDetailsService } from 'src/app/shared/services/appointment-details.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  constructor(private appoinmentDetails: AppointmentDetailsService) { }

  ngOnInit(): void {
  }

  public appointmentDetails() {
    this.appoinmentDetails.show();
  }
}
