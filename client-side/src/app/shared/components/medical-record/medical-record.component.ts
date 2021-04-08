import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html'
})
export class MedicalRecordComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  public close() {
    this.bsModalRef.hide();
  }
}
