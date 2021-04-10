import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppointmentDetailsComponent } from '../components/appointment-details/appointment-details.component';
import { TimeSlotComponent } from '../components/time-slot/time-slot.component';

@Injectable({
  providedIn: 'root'
})
export class ModalServicesService {
  public bsModelRef!: BsModalRef;

  constructor(private modalService: BsModalService) { }

  public appointmentDetails() {
    this.bsModelRef = this.modalService.show(AppointmentDetailsComponent);
  }

  public timeSlot() {
    this.bsModelRef = this.modalService.show(TimeSlotComponent);
  }
}
