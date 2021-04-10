import { Component, OnInit } from '@angular/core';
import { ModalServicesService } from '../../services/modal-services.service';

@Component({
  selector: 'app-pages-action-for-user-dashboard',
  templateUrl: './pages-action-for-user-dashboard.component.html'
})
export class PagesActionForUserDashboardComponent implements OnInit {

  constructor(private modals: ModalServicesService) { }

  ngOnInit(): void {
  }

  public appointmentDetails() {
    this.modals.appointmentDetails();
  }
}
