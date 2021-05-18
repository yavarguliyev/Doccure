import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../../models/user';

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
  @Input() slug: string;
  @Input() user: User;
  public loading = false;

  constructor() { }

  ngOnInit() { }

  public submit(event: Event, slug: string) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement;
    this.loading = true;

    parent.removeChild(parent.lastElementChild);
    parent.lastElementChild.classList.remove('d-none');
  }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }
}
