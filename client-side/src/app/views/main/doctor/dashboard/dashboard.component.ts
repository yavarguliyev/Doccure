import {
  Component,
  ElementRef,
  Input,
  OnInit,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
  @ViewChildren('app') apps!: QueryList<ElementRef>;
  @ViewChildren('activeLink') activeLinks!: QueryList<ElementRef>;
  @Input() patients: User[] = [];

  constructor() {}

  ngOnInit(): void {}

  public setApp(event: Event) {
    event.preventDefault();

    const target = event.currentTarget as HTMLElement;
    const href = target.getAttribute('href')?.replace('#', '');
    const navLink: ElementRef[] = this.activeLinks.toArray();
    const app: ElementRef[] = this.apps.toArray();

    app.forEach((x) => {
      x.nativeElement.className = 'tab-pane';
      if (x.nativeElement.getAttribute('id') === href) {
        x.nativeElement.className = 'tab-pane show active';
      }
    });

    navLink.forEach((x) => (x.nativeElement.className = 'nav-link'));

    target.classList.add('active');
  }
}
