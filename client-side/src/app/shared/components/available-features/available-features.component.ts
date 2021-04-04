import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Feature, FeatureF } from '../../models/feature';
import { MainPageSettings } from '../../models/main-page-settings';

@Component({
  selector: 'app-available-features',
  templateUrl: './available-features.component.html',
})
export class AvailableFeaturesComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('available', { static: false })
  private availableSettings!: ElementRef;

  public slideConfig = { slidesToShow: 4, slidesToScroll: 4 };

  public features: Feature[] = [];

  constructor(private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.inserHTML();

    const f1 = new FeatureF(
      1,
      'Patient Ward',
      'assets/img/features/feature-01.jpg'
    );
    const f2 = new FeatureF(
      2,
      'Test Room',
      'assets/img/features/feature-02.jpg'
    );
    const f3 = new FeatureF(3, 'ICU', 'assets/img/features/feature-03.jpg');
    const f4 = new FeatureF(
      4,
      'Laboratory',
      'assets/img/features/feature-04.jpg'
    );
    const f5 = new FeatureF(
      5,
      'Operation',
      'assets/img/features/feature-05.jpg'
    );
    const f6 = new FeatureF(5, 'Medical', 'assets/img/features/feature-06.jpg');

    this.features.push(f1);
    this.features.push(f2);
    this.features.push(f3);
    this.features.push(f4);
    this.features.push(f5);
    this.features.push(f6);
  }

  private inserHTML() {
    this.changeDetectorRef.detectChanges();
    this.availableSettings.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.availableTitle
    );

    this.availableSettings.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.availableSubTitle
    );
  }
}
