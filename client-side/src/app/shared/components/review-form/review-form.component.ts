import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ReviewReplyFormValues } from '../../models/review';
import { User } from '../../models/user';
import { ReviewService } from '../../services/review.service';

@Component({
  selector: 'app-review-form',
  templateUrl: './review-form.component.html',
})
export class ReviewFormComponent implements OnInit {
  @ViewChild('reviewForm') reviewForm: NgForm;
  @Input() isDoctorProfile = false;
  @Input() id = 0;
  public textLength = 100;
  @Input() textContent: string;
  public loading = false;

  constructor(private reviewService: ReviewService) {}

  ngOnInit() {}

  public submit(event: Event, reviewId: number) {
    event.preventDefault();
    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement.firstElementChild;
    this.loading = true;
    const currentUser: User = JSON.parse(localStorage.getItem('token'));
    const reply: ReviewReplyFormValues = new ReviewReplyFormValues(
      this.textContent,
      reviewId,
      null,
      null
    );

    if (currentUser && currentUser.role === 'Doctor') {
      reply.doctorId = currentUser.id;
    } else if (currentUser && currentUser.role === 'Patient') {
      reply.patientId = currentUser.id;
    }

    this.reviewService
      .sendReviewReply(reply)
      .then(() => this.reviewForm.reset())
      .finally(() => {
        this.loading = false;

        parent.classList.remove('d-none');
        parent.parentElement.removeChild(parent.parentElement.lastElementChild);
      });
  }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }
}
