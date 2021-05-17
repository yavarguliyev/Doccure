import {
  Directive,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Directive({
  selector: '[app_element_loader]',
})
export class Element_Loader_Directive implements OnInit {
  private subscription: Subscription;
  @Input() show: boolean;

  @Output('ngInit') initEvent: EventEmitter<ElementRef> = new EventEmitter();
  constructor() {}

  ngOnInit() {
    this.subscription = timer(0, 1)
      .pipe(
        switchMap(async () => {
          if (this.show) {
            this.initEvent.emit();
            this.subscription.unsubscribe();
          }
        })
      )
      .subscribe();
  }
}
