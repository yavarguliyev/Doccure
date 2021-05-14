import {
  ApplicationRef,
  Component,
  ComponentFactoryResolver,
  ElementRef,
  EmbeddedViewRef,
  Injector,
  OnInit,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { ReviewFormComponent } from 'src/app/shared/components/review-form/review-form.component';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
})
export class ReviewsComponent implements OnInit {
  @ViewChildren('choosenForm') chooseForms: QueryList<ElementRef>;
  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector,
    private appRef: ApplicationRef
  ) {}

  ngOnInit(): void {}

  public addReplyText(id: number) {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(ReviewFormComponent)
      .create(this.injector);

    componentRef.instance.submit = this.submit;
    this.appRef.attachView(componentRef.hostView);
    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    const element: ElementRef[] = this.chooseForms.toArray();
    element.forEach(x => {
      const elementId: number = parseInt(x.nativeElement.getAttribute('id'));
      if (elementId === id && x.nativeElement.lastElementChild !== domElem) {
        x.nativeElement.appendChild(domElem);
        x.nativeElement.querySelector('.comment-btn').classList.add('d-none');
      }
    });
  }

  public submit(event: Event) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement.parentElement.firstElementChild;
    parent.classList.remove('d-none');
    parent.parentElement.removeChild(parent.parentElement.lastElementChild);
  }
}
