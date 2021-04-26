import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-time-slot-form-input',
  templateUrl: './time-slot-form-input.component.html',
})
export class TimeSlotFormInputComponent implements OnInit {
  @Input() row!: ElementRef;
  @Input() main = false;
  @Input() fg!: FormGroup;
  public maxDate!: Date;
  public formControl = new FormControl('');

  constructor() {}

  ngOnInit(): void {
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() + 1);
    this.maxDate.setMonth(this.maxDate.getMonth() + 31);
  }

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
