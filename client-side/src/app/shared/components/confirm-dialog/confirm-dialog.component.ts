import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
})
export class ConfirmDialogComponent implements OnInit {
  public title!: string;
  public message!: string;
  public btnOkText!: string;
  public btnCancelText!: string;
  public result!: boolean;

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {}

  confirm() {
    this.result = true;
    this.bsModalRef.hide();
  }

  decline() {
    this.result = false;
    this.bsModalRef.hide();
  }
}
