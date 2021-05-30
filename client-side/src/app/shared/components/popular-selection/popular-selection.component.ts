import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { MainPageSettings } from '../../models/main-page-settings';
import { User } from '../../models/user';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-popular-selection',
  templateUrl: './popular-selection.component.html',
})
export class PopularSelectionComponent implements OnInit {
  @Input() setting: MainPageSettings;
  @ViewChild('popularTitle', { static: false })
  private popularTitle: ElementRef;
  @ViewChild('popularText', { static: false })
  private popularText: ElementRef;

  public slideConfig = { slidesToShow: 3, slidesToScroll: 3 };

  public customOptions: OwlOptions = {
    loop: true,
    margin: 30,
    nav: false,
    dots: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 3
      },
      1000: {
        items: 4
      },
      1200: {
        items: 5
      },
      1400: {
        items: 5
      }
    }
  };

  public doctors: User[] = [];
  constructor(private changeDetectorRef: ChangeDetectorRef, private settingService: SettingsService) {}

  ngOnInit(): void {
    this.insertHTML();
    this.settingService.getDoctors().subscribe((x) => this.doctors = x);
  }

  private insertHTML() {
    this.changeDetectorRef.detectChanges();

    this.popularTitle.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.popularTitle,
    );

    this.popularTitle.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.popularSubTitle,
    );

    this.popularText.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.popularText,
    );
  }
}
