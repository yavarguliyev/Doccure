import {
  Component,
  ElementRef,
  Input,
  OnInit,
  QueryList,
  ViewChildren,
} from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { PagesPhotos } from 'src/app/shared/models/pages-images';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ConfirmService } from 'src/app/shared/services/confirm.service';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  public show = false;
  public user: User;
  @Input() header: MainPageSettings;
  public headerPhoto: PagesPhotos;
  @ViewChildren('navItem') navItems: QueryList<ElementRef>;

  constructor(
    private api: AuthService,
    private confirm: ConfirmService,
    private settingService: SettingsService
  ) {}

  ngOnInit(): void {
    this.apiResponse();
    this.checkUser();
  }

  public openNav(event: Event) {
    event.preventDefault();
    const navItem: ElementRef[] = this.navItems.toArray();
    const target = event.currentTarget as HTMLElement;
    const next = target.nextElementSibling;
    navItem.forEach(x => {
      const item = x.nativeElement;
      if (item === next) {
        item.style.display !== 'block' ? (item.style.display = 'block') : (item.style.display = 'none');
      }
    });
  }

  public logout() {
    this.confirm
      .confirm('Confirm logout', 'Do you want to logout?')
      .subscribe((result) => {
        if (result) {
          this.api.logout();
        }
      });
  }

  public loggedInUser(event: Event) {
    event.preventDefault();
    this.show = !this.show;
  }

  public parentElement(event: Event) {
    event.preventDefault();
    this.parentElementChilds();
  }

  public closeMenu(event: Event) {
    event.preventDefault();
    this.parentElementChilds();
  }

  private checkUser() {
    this.user = this.api.checkUser();
  }

  private parentElementChilds() {
    document.querySelector('html')?.classList.toggle('menu-opened');
    document.querySelector('#main-html-child')?.classList.toggle('opened');
  }

  private apiResponse() {
    this.settingService
      .getPagesPhotots('HeaderAndInvoice')
      .subscribe((response) => (this.headerPhoto = response));
  }
}
