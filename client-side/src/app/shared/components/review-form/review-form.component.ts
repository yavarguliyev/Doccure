import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'lib-review-form',
  templateUrl: './review-form.component.html',
})
export class ReviewFormComponent implements OnInit {
  @Input() isDoctorProfile = false;
  @Input() openForm = false;
  constructor() { }

  ngOnInit() {
  }

  public submit(event: Event) { }
}
