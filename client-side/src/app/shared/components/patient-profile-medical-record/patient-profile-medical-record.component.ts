import { Component, OnInit } from '@angular/core';
import { ModalServicesService } from '../../services/modal-services.service';

@Component({
  selector: 'app-patient-profile-medical-record',
  templateUrl: './patient-profile-medical-record.component.html',
})
export class PatientProfileMedicalRecordComponent implements OnInit {
  constructor(private modalService: ModalServicesService) {}

  ngOnInit(): void {}

  public openAddEditMedicalRecor() {
    this.modalService.medicalRecord();
  }

  public openAppointmentDetails() {
    this.modalService.appointmentDetails();
  }
}
