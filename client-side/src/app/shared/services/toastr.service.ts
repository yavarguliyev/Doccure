import { Injectable } from '@angular/core';
import { ToastrService as Toast } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class ToastrService {
  constructor(private toastr: Toast) {}

  public toastBody(): any {
    return {
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      closeButton: true,
      progressBar: true,
      progressAnimation: 'increasing',
      easing: '500',
      easeTime: '500',
      enableHtml: true,
    };
  }

  public success(message: string, title: string) {
    this.toastr.success(message, title, this.toastBody());
  }

  public info(message: string, title: string) {
    this.toastr.info(message, title, this.toastBody());
  }

  public warning(message: string, title: string) {
    this.toastr.warning(message, title, this.toastBody());
  }

  public error(message: string, title: string) {
    this.toastr.error(message, title, this.toastBody());
  }
}
