import {
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-time-slot-form',
  templateUrl: './time-slot-form.component.html',
})
export class TimeSlotFormComponent implements OnInit {
  @ViewChild('row_count') row!: ElementRef;

  public fg: FormGroup = new FormGroup({});
  public maxDate!: Date;

  constructor(private renderer: Renderer2, private elementRef: ElementRef) {}

  ngOnInit(): void {
    this.intitializeForm();
    this.maxDate = new Date();
  }

  private intitializeForm() {
    this.fg.patchValue({
      start: '',
      end: '',
    });
  }

  public addRowCount() {
    this.renderer.appendChild(
      this.row.nativeElement,
      this.createElementForRow()
    );
  }

  private createElementForRow() {
    const div: HTMLDivElement = this.renderer.createElement('div');

    div.innerHTML = `<div class="col-12 col-md-10">
                        <div class="row form-row">
                            <div class="col-12 col-md-6">
                              <div class="form-group">
                                <label>Start Time</label>
                                <input type="time" class="form-control">
                              </div>
                            </div>
                            <div class="col-12 col-md-6">
                              <div class="form-group">
                                <label>End Time</label>
                                <input type="time" class="form-control">
                              </div>
                            </div>
                        </div>
                     </div>
                     <div class="col-12 col-md-2">
                        <label class="d-md-block d-sm-none d-none">&nbsp;</label>
                        <a ${this.elementRef.nativeElement.addEventListener(
                          'click',
                          this.removeAddedElement.bind(this)
                        )} href="javascript:void(0)" class="btn btn-danger trash">
                          <i class="far fa-trash-alt"></i>
                        </a>
                     </div>`;

    div.className = 'row form-row hours-cont';

    return div;
  }

  public removeAddedElement(event: Event) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const parent = target.parentElement?.parentElement;
    const r: HTMLElement[] = this.row.nativeElement.children;
    if (r.length > 1) {
      for (const item of r) {
        if (item === parent) {
          this.row.nativeElement.removeChild(item);
        }
      }
    }
  }

  public submitAddOrEdit() {
    console.log(this.fg.value);
  }
}
