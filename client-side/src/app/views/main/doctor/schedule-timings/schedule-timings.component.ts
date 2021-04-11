import {
  Component,
  ElementRef,
  OnInit,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { ConfirmService } from 'src/app/shared/services/confirm.service';
import { ModalServicesService } from 'src/app/shared/services/modal-services.service';
import { ToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-schedule-timings',
  templateUrl: './schedule-timings.component.html',
})
export class ScheduleTimingsComponent implements OnInit {
  @ViewChildren('nav_link') navLinks!: QueryList<ElementRef>;
  @ViewChildren('tab') tabs!: QueryList<ElementRef>;

  constructor(
    private modalService: ModalServicesService,
    private confirm: ConfirmService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {}

  public switchTab(event: Event) {
    event.preventDefault();

    const target = event.target as HTMLElement;
    const href = target.getAttribute('href')?.replace('#', '');
    const navLink: ElementRef[] = this.navLinks.toArray();
    const tab: ElementRef[] = this.tabs.toArray();

    tab.forEach((x) => {
      x.nativeElement.className = 'tab-pane fade';
      if (x.nativeElement.getAttribute('id') === href) {
        x.nativeElement.className = 'tab-pane fade show active';
      }
    });

    navLink.forEach((x) => (x.nativeElement.className = 'nav-link'));

    target.classList.add('active');
  }

  public openTimeSlotCreateUpdate() {
    this.modalService.timeSlot();
  }

  public removeExistingTimeSlot() {
    this.confirm
      .confirm('Remove time slot', 'Do you want to remove?')
      .forEach((result) => {
        if (result) {
          this.toastr.success('Selected time slot successfully removed!', 'Success');
        }
      });
  }
}
