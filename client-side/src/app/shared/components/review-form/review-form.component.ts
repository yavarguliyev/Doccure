import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-lib-review-form',
  templateUrl: './review-form.component.html',
})
export class ReviewFormComponent implements OnInit {
  @Input() isDoctorProfile = false;
  public textLength = 100;
  constructor() { }

  ngOnInit() {
  }

  public submit(event: Event) { }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }
}
