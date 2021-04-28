import {
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
  ViewEncapsulation,
} from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-time-slot-form-input',
  templateUrl: './time-slot-form-input.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class TimeSlotFormInputComponent implements OnInit {
  @ViewChild('startPicker') startPicker: any;
  @ViewChild('endPicker') endPicker: any;

  @Input() row!: ElementRef;
  @Input() main = false;
  @Input() fg!: FormGroup;

  @Input() starts!: FormArray;
  @Input() ends!: FormArray;

  constructor() {}

  ngOnInit(): void { }

  public removeAddedElement(event: Event) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement?.parentElement?.parentElement;
    const r: HTMLElement[] = this.row.nativeElement.children;
    if (r.length > 1) {
      for (const item of r) {
        if (item === parent) {
          this.row.nativeElement.removeChild(item);
        }
      }
    }
  }
}
