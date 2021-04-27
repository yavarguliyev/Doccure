import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppointmentDetailsComponent } from '../components/appointment-details/appointment-details.component';
import { MedicalRecordComponent } from '../components/medical-record/medical-record.component';
import { TimeSlotComponent } from '../components/time-slot/time-slot.component';

@Injectable({
  providedIn: 'root'
})
export class ModalServicesService {
  private bsModelRef!: BsModalRef;
  private config = {
    animated: true,
    class: 'gray modal-md'
  };

  constructor(private modalService: BsModalService) { }

  public appointmentDetails() {
    this.bsModelRef = this.modalService.show(AppointmentDetailsComponent, this.config);
  }

  public timeSlot() {
    this.bsModelRef = this.modalService.show(TimeSlotComponent, this.config);
  }

  public medicalRecord() {
    this.bsModelRef = this.modalService.show(MedicalRecordComponent, this.config);
  }
}
