import { AfterViewInit, Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { EnumType } from 'typescript';

@Component({
  selector: 'app-input-select',
  templateUrl: './input-select.component.html'
})
export class InputSelectComponent implements ControlValueAccessor, AfterViewInit {
  @Input() label!: string;
  @Input() values: any;

  public formControl = new FormControl('');

  constructor(@Self() public ngControl: NgControl) {
    ngControl.valueAccessor = this;
  }

  ngAfterViewInit(): void {
    this.formControl = this.ngControl.control as FormControl;
  }

  writeValue(obj: any): void { }

  registerOnChange(fn: any): void { }

  registerOnTouched(fn: any): void { }
}
