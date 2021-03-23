import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecialitiesComponent } from './specialities/specialities.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { PopularSelectionComponent } from './popular-selection/popular-selection.component';
import { AvailableFeaturesComponent } from './available-features/available-features.component';
import { BlogSectionComponent } from './blog-section/blog-section.component';
import { RouterModule } from '@angular/router';
import { HomeBannerComponent } from './home-banner/home-banner.component';

@NgModule({
  declarations: [SpecialitiesComponent, PopularSelectionComponent, AvailableFeaturesComponent, BlogSectionComponent, HomeBannerComponent],
  imports: [CommonModule, NgbModule, CarouselModule, RouterModule],
  exports: [SpecialitiesComponent, PopularSelectionComponent, AvailableFeaturesComponent, BlogSectionComponent, HomeBannerComponent],
})
export class ComponentsHelperModule {}
