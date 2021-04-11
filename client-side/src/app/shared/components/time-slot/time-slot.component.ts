import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-time-slot',
  templateUrl: './time-slot.component.html',
})
export class TimeSlotComponent implements OnInit {
  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {}

  public close() {
    this.bsModalRef.hide();
  }
}
