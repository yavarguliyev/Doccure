import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CommentReplyFormValues } from '../../models/comment';
import { User } from '../../models/user';
import { CommentService } from '../../services/comment.service';
import { ToastrService } from '../../services/toastr.service';

@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
})
export class CommentFormComponent implements OnInit {
  @ViewChild('replyForm') replyForm: NgForm;
  @Input() isDoctorProfile = false;
  @Input() id = 0;
  public textLength = 100;
  @Input() textContent: string;
  @Input() emailContent: string;
  @Input() slug: string;
  @Input() user: User;
  public loading = false;

  constructor(
    private commentService: CommentService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {}

  public submit(event: Event, slug: string, id) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement;
    this.loading = true;

    if (!this.emailContent) {
      if (this.user) {
        this.emailContent = this.user.email;
        return;
      } else {
        this.toastrService.info('Email must not be empty', 'Info');
      }
    }

    const reply: CommentReplyFormValues = new CommentReplyFormValues(
      this.textContent,
      slug,
      this.emailContent,
      id
    );

    this.commentService
      .sendCommentReply(reply)
      .then(() => this.replyForm.reset())
      .catch((e) => console.log(e))
      .finally(() => {
        this.loading = false;
        parent.removeChild(parent.lastElementChild);
        parent.lastElementChild.classList.remove('d-none');
      });
  }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length, 16);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }
}
