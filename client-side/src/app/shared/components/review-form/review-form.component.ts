import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-lib-review-form',
  templateUrl: './review-form.component.html',
})
export class ReviewFormComponent implements OnInit {
  @ViewChild('reviewForm') reviewForm: NgForm;
  @Input() isDoctorProfile = false;
  public id = 0;
  public textLength = 100;
  public textContent: string;
  public loading = false;
  constructor() { }

  ngOnInit() { }

  public submit(event: Event, reviewId: number) { }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }
}
