import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecialitiesComponent } from './specialities/specialities.component';
import { PopularSelectionComponent } from './popular-selection/popular-selection.component';
import { AvailableFeaturesComponent } from './available-features/available-features.component';
import { BlogSectionComponent } from './blog-section/blog-section.component';
import { RouterModule } from '@angular/router';
import { HomeBannerComponent } from './home-banner/home-banner.component';
import { MainBreadcrumbComponent } from './main-breadcrumb/main-breadcrumb.component';
import { BlogSidebarComponent } from './blog-sidebar/blog-sidebar.component';
import { DoctorSidebarComponent } from './doctor-sidebar/doctor-sidebar.component';
import { InputTextComponent } from './input-text/input-text.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputDateComponent } from './input-date/input-date.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { InputSelectComponent } from './input-select/input-select.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { TimeSlotComponent } from './time-slot/time-slot.component';

@NgModule({
  declarations: [
    SpecialitiesComponent,
    PopularSelectionComponent,
    AvailableFeaturesComponent,
    BlogSectionComponent,
    HomeBannerComponent,
    MainBreadcrumbComponent,
    BlogSidebarComponent,
    DoctorSidebarComponent,
    InputTextComponent,
    InputDateComponent,
    InputSelectComponent,
    ConfirmDialogComponent,
    AppointmentDetailsComponent,
    MedicalRecordComponent,
    TimeSlotComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    CarouselModule
  ],
  exports: [
    SpecialitiesComponent,
    PopularSelectionComponent,
    AvailableFeaturesComponent,
    BlogSectionComponent,
    HomeBannerComponent,
    MainBreadcrumbComponent,
    BlogSidebarComponent,
    DoctorSidebarComponent,
    InputTextComponent,
    InputDateComponent,
    InputSelectComponent,
    ConfirmDialogComponent,
    AppointmentDetailsComponent
  ],
})
export class ComponentsHelperModule {}
