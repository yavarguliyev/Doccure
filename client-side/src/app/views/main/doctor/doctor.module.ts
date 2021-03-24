import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorComponent } from './doctor.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { MyPatientsComponent } from './my-patients/my-patients.component';
import { ScheduleTimingsComponent } from './schedule-timings/schedule-timings.component';
import { InvoicesComponent } from './invoices/invoices.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { MessagesComponent } from './messages/messages.component';
import { ProfileSettingsComponent } from './profile-settings/profile-settings.component';
import { SocialMediaComponent } from './social-media/social-media.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { PatientProfileComponent } from './patient-profile/patient-profile.component';
import { DoctorBlogComponent } from './doctor-blog/doctor-blog.component';
import { InvoicesDetailsComponent } from './invoices-details/invoices-details.component';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';

@NgModule({
  declarations: [
    DoctorComponent,
    DashboardComponent,
    AppointmentsComponent,
    MyPatientsComponent,
    ScheduleTimingsComponent,
    InvoicesComponent,
    ReviewsComponent,
    MessagesComponent,
    ProfileSettingsComponent,
    SocialMediaComponent,
    ChangePasswordComponent,
    PatientProfileComponent,
    DoctorBlogComponent,
    InvoicesDetailsComponent,
  ],
  imports: [CommonModule, DoctorRoutingModule, ComponentsHelperModule],
})
export class DoctorModule {}
