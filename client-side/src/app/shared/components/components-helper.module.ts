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
import { PatientProfileMedicalRecordComponent } from './patient-profile-medical-record/patient-profile-medical-record.component';
import { PatientProfilePrescriptionComponent } from './patient-profile-prescription/patient-profile-prescription.component';
import { PatientProfileBillingComponent } from './patient-profile-billing/patient-profile-billing.component';
import { PatientProfileAppointmentComponent } from './patient-profile-appointment/patient-profile-appointment.component';
import { PatientUserTabsComponent } from './patient-user-tabs/patient-user-tabs.component';
import { InvoiceTableComponent } from './invoice-table/invoice-table.component';
import { AuthAuthComponent } from './auth/auth-auth.component';
import { TimeSlotFormInputComponent } from './time-slot-form-input/time-slot-form-input.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';
import { ChatMessageComponent } from './chat-message/chat-message.component';
import { ChatLefSideBarComponent } from './chat-lef-side-bar/chat-lef-side-bar.component';
import { TimeagoModule } from 'ngx-timeago';
import { ReviewFormComponent } from './review-form/review-form.component';
import { Element_Loader_Directive } from '../directives/element_loader.directive';
import { CommentComponent } from './comment/comment.component';
import { CommentFormComponent } from './comment-form/comment-form.component';
import { PatientDashboardComponent } from './patient-dashboard/patient-dashboard.component';
import { ChatParentMessagesComponent } from './chat-parent-messages/chat-parent-messages.component';
import { ReviewMainListComponent } from './review-main-list/review-main-list.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FileUploadModule } from 'ng2-file-upload';

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
    PatientProfileMedicalRecordComponent,
    PatientProfilePrescriptionComponent,
    PatientProfileBillingComponent,
    PatientProfileAppointmentComponent,
    PatientUserTabsComponent,
    InvoiceTableComponent,
    AuthAuthComponent,
    TimeSlotFormInputComponent,
    ChatMessageComponent,
    ChatLefSideBarComponent,
    ReviewFormComponent,
    Element_Loader_Directive,
    CommentComponent,
    CommentFormComponent,
    PatientDashboardComponent,
    ChatParentMessagesComponent,
    ReviewMainListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    TimeagoModule.forRoot(),
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
      startFromZero: false,
    }),
    MatDatepickerModule,
    MatInputModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule,
    BsDropdownModule.forRoot(),
    FileUploadModule
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
    PagesActionForUserDashboardComponent,
    PatientProfileMedicalRecordComponent,
    PatientProfilePrescriptionComponent,
    PatientProfileBillingComponent,
    PatientProfileAppointmentComponent,
    PatientUserTabsComponent,
    InvoiceTableComponent,
    AuthAuthComponent,
    TimeSlotFormInputComponent,
    ChatMessageComponent,
    ChatLefSideBarComponent,
    ReviewFormComponent,
    CommentComponent,
    CommentFormComponent,
    PatientDashboardComponent,
    ChatParentMessagesComponent,
    ReviewMainListComponent,
    FileUploadModule
  ],
})
export class ComponentsHelperModule {}
