import {
  ApplicationRef,
  Component,
  ComponentFactoryResolver,
  ElementRef,
  EmbeddedViewRef,
  Injector,
  OnInit,
  ViewChild,
} from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TimeSlotFormInputComponent } from '../time-slot-form-input/time-slot-form-input.component';

@Component({
  selector: 'app-time-slot',
  templateUrl: './time-slot.component.html',
})
export class TimeSlotComponent implements OnInit {
  @ViewChild('row_count') row: ElementRef;

  public fg: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private bsModalRef: BsModalRef,
    private componentFactoryResolver: ComponentFactoryResolver,
    private appRef: ApplicationRef,
    private injector: Injector
  ) {}

  ngOnInit(): void {
    this.intitializeForm();
  }

  private intitializeForm() {
    this.fg = this.fb.group({
      starts: this.fb.array([new FormControl(new Date(), Validators.required)]),
      ends: this.fb.array([new FormControl(new Date(), Validators.required)]),
    });
  }

  get starts(): FormArray {
    return this.fg.get('starts') as FormArray;
  }

  get ends(): FormArray {
    return this.fg.get('ends') as FormArray;
  }

  public addRowCount() {
    const componentRef = this.componentFactoryResolver
      .resolveComponentFactory(TimeSlotFormInputComponent)
      .create(this.injector);

    componentRef.instance.row = this.row;
    componentRef.instance.fg = this.fg;
    componentRef.instance.starts = this.starts;
    componentRef.instance.ends = this.ends;
    this.appRef.attachView(componentRef.hostView);

    const domElem = (componentRef.hostView as EmbeddedViewRef<any>)
      .rootNodes[0] as HTMLElement;

    this.row.nativeElement.appendChild(domElem);
  }

  public submitAddOrEdit() {
    console.log(this.starts.value);
  }

  public close() {
    this.bsModalRef.hide();
  }
}
