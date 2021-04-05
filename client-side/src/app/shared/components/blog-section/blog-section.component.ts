import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Blog } from '../../models/blog';
import { MainPageSettings } from '../../models/main-page-settings';

@Component({
  selector: 'app-blog-section',
  templateUrl: './blog-section.component.html',
})
export class BlogSectionComponent implements OnInit {
  @Input() setting!: MainPageSettings;
  @ViewChild('blog', { static: false })
  private blogSettings!: ElementRef;

  @Input() blogs: Blog[] = [];

  constructor(private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.insertHTML();
  }

  private insertHTML() {
    this.changeDetectorRef.detectChanges();
    this.blogSettings.nativeElement.insertAdjacentHTML(
      'afterbegin',
      this.setting.blogsAndNewsTitle
    );

    this.blogSettings.nativeElement.insertAdjacentHTML(
      'beforeend',
      this.setting.blogsAndNewsSubTitle
    );
  }
}
