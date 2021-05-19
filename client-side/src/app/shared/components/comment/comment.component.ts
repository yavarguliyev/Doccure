import {
  ApplicationRef,
  Component,
  ComponentFactoryResolver,
  ElementRef,
  EmbeddedViewRef,
  Injector,
  Input,
  OnInit,
  QueryList,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Comment, CommentFormValues } from '../../models/comment';
import { User } from '../../models/user';
import { CommentService } from '../../services/comment.service';
import { ToastrService } from '../../services/toastr.service';
import { CommentFormComponent } from '../comment-form/comment-form.component';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
})
export class CommentComponent implements OnInit {
  @ViewChildren('choosenForm') chooseForms: QueryList<ElementRef>;
  @ViewChild('commentForm') commentForm: NgForm;
  @Input() user: User;
  public textLength = 100;
  public textContent: string;
  public emailContent: string;
  @Input() slug: string;
  @Input() commentThread$: Observable<Comment[]>;
  @Input() loading = false;

  constructor(
    private injector: Injector,
    private appRef: ApplicationRef,
    private componentFactoryResolver: ComponentFactoryResolver,
    private commentService: CommentService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {}

  public addReplyText(id: number) {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(CommentFormComponent)
      .create(this.injector);

    componentRef.instance.id = id;
    componentRef.instance.textContent = this.textContent;
    componentRef.instance.loading = this.loading;
    componentRef.instance.user = this.user;
    componentRef.instance.slug = this.slug;

    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    const element: ElementRef[] = this.chooseForms.toArray();
    element.forEach((x) => {
      const elementId: number = parseInt(x.nativeElement.getAttribute('id'));
      if (elementId === id && x.nativeElement.lastElementChild !== domElem) {
        x.nativeElement.appendChild(domElem);
        x.nativeElement.querySelector('.comment-btn').classList.add('d-none');
      }
    });
  }

  public onKeyUp(event: any): void {
    const maxLength = 100;
    const length = parseInt(event.target.value.length);
    if (this.textLength <= 100) {
      this.textLength = maxLength - length;
    }
  }

  public submit() {
    if (!this.emailContent) {
      if (this.user) {
        this.emailContent = this.user.email;
        return;
      } else {
        this.toastrService.info('Email must not be empty', 'Info');
      }
    }

    const comment: CommentFormValues = new CommentFormValues(
      this.textContent,
      this.slug,
      this.emailContent
    );

    this.commentService
      .sendComment(comment)
      .then(() => this.commentForm.reset())
      .catch(e => console.log(e))
      .finally(() => {
        this.loading = false;
      });
  }
}
