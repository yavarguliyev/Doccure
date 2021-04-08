import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppointmentDetailsComponent } from '../components/appointment-details/appointment-details.component';

@Injectable({
  providedIn: 'root'
})
export class AppointmentDetailsService {
  public bsModelRef!: BsModalRef;

  constructor(private modalService: BsModalService) { }

  public show() {
    this.bsModelRef = this.modalService.show(AppointmentDetailsComponent);
  }
}
