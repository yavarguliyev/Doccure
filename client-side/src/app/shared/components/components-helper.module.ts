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
import { DoctorDashboardPatientsAppointmentComponent } from './doctor-dashboard-patients-appointment/doctor-dashboard-patients-appointment.component';
import { DashboardCanvasComponent } from './dashboard-canvas/dashboard-canvas.component';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { PagesActionForUserDashboardComponent } from './pages-action-for-user-dashboard/pages-action-for-user-dashboard.component';

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
    DoctorDashboardPatientsAppointmentComponent,
    DashboardCanvasComponent,
    PagesActionForUserDashboardComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    CarouselModule,
    NgCircleProgressModule.forRoot({
      backgroundGradient: true,
      backgroundColor: '#ffffff',
      backgroundGradientStopColor: '#c0c0c0',
      backgroundPadding: -10,
      radius: 60,
      maxPercent: 100,
      outerStrokeWidth: 10,
      outerStrokeColor: '#61A9DC',
      innerStrokeWidth: 0,
      subtitleColor: '#444444',
      showInnerStroke: false,
      startFromZero: false
    }),
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
    AppointmentDetailsComponent,
    DoctorDashboardPatientsAppointmentComponent,
    DashboardCanvasComponent,
    PagesActionForUserDashboardComponent
  ],
})
export class ComponentsHelperModule {}
