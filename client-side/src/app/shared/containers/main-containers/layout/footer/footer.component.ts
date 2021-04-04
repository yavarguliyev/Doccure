import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MainPageSettings } from 'src/app/shared/models/main-page-settings';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent implements OnInit {
  public user!: User;
  @Input() footer!: MainPageSettings;

  @ViewChild('footerAddress', { static: false })
  private footerAddress!: ElementRef;
  @ViewChild('footerDesc', { static: false })
  private footerDesc!: ElementRef;

  constructor(
    private api: AuthService,
    private changeDetectorRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.user = this.api.checkUser();
    this.insertHTML();
  }

  private insertHTML() {
    this.changeDetectorRef.detectChanges();

    this.footerAddress?.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.footer.address
    );

    this.footerDesc?.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.footer.footerDesc
    );
  }
}
