import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html'
})
export class AppointmentDetailsComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  public close() {
    this.bsModalRef.hide();
  }
}
