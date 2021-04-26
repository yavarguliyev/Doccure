import { AfterViewInit, Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-input-date',
  templateUrl: './input-date.component.html',
})
export class InputDateComponent implements ControlValueAccessor, AfterViewInit {
  @Input() label!: string;
  @Input() maxDate!: Date;
  public bsConfig!: Partial<BsDatepickerConfig>;

  public formControl = new FormControl('');

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
    this.bsConfig = {
      isAnimated: true,
      containerClass: 'theme-blue',
      dateInputFormat: 'DD/MM/YYYY'
    };
  }

  ngAfterViewInit(): void {
    this.formControl = this.ngControl.control as FormControl;
  }

  writeValue(obj: any): void { }

  registerOnChange(fn: any): void { }

  registerOnTouched(fn: any): void { }
}
