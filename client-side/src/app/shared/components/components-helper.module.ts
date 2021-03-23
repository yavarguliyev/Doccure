import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecialitiesComponent } from './specialities/specialities.component';
import { PopularSelectionComponent } from './popular-selection/popular-selection.component';
import { AvailableFeaturesComponent } from './available-features/available-features.component';
import { BlogSectionComponent } from './blog-section/blog-section.component';
import { RouterModule } from '@angular/router';
import { HomeBannerComponent } from './home-banner/home-banner.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { MainBreadcrumbComponent } from './main-breadcrumb/main-breadcrumb.component';
import { BlogSidebarComponent } from './blog-sidebar/blog-sidebar.component';

@NgModule({
  declarations: [
    SpecialitiesComponent,
    PopularSelectionComponent,
    AvailableFeaturesComponent,
    BlogSectionComponent,
    HomeBannerComponent,
    MainBreadcrumbComponent,
    BlogSidebarComponent,
  ],
  imports: [CommonModule, RouterModule, SlickCarouselModule],
  exports: [
    SpecialitiesComponent,
    PopularSelectionComponent,
    AvailableFeaturesComponent,
    BlogSectionComponent,
    HomeBannerComponent,
    MainBreadcrumbComponent,
    BlogSidebarComponent
  ],
})
export class ComponentsHelperModule {}
