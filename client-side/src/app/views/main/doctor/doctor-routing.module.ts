import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthDoctorGuard } from 'src/app/shared/guards/auth-doctor.guard';
import { AppointmentsComponent } from './appointments/appointments.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DoctorBlogComponent } from './doctor-blog/doctor-blog.component';
import { DoctorComponent } from './doctor.component';
import { InvoicesComponent } from './invoices/invoices.component';
import { MessagesComponent } from './messages/messages.component';
import { MyPatientsComponent } from './my-patients/my-patients.component';
import { PatientProfileComponent } from './patient-profile/patient-profile.component';
import { ProfileSettingsComponent } from './profile-settings/profile-settings.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { ScheduleTimingsComponent } from './schedule-timings/schedule-timings.component';
import { SocialMediaComponent } from './social-media/social-media.component';

const routes: Routes = [
  {
    path: '',
    component: DoctorComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthDoctorGuard],
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        data: { title: 'Doccure | Doctor | Dashboard' },
      },
      {
        path: 'appointments',
        component: AppointmentsComponent,
        data: { title: 'Doccure | Doctor | Appointments' },
      },
      {
        path: 'my-patients',
        component: MyPatientsComponent,
        data: { title: 'Doccure | Doctor | My-Patients' },
      },
      {
        path: 'patient-profile/:slug',
        component: PatientProfileComponent,
        data: { title: 'Doccure | Doctor | Patient-Profile' },
      },
      {
        path: 'schedule-timings',
        component: ScheduleTimingsComponent,
        data: { title: 'Doccure | Doctor | Schedule-Timings' },
      },
      {
        path: 'invoices',
        component: InvoicesComponent,
        data: { title: 'Doccure | Doctor | Invoices' },
      },
      {
        path: 'reviews',
        component: ReviewsComponent,
        data: { title: 'Doccure | Doctor | Reviews' },
      },
      {
        path: 'message',
        component: MessagesComponent,
        data: { title: 'Doccure | Doctor | Message' },
      },
      {
        path: 'profile-settings',
        component: ProfileSettingsComponent,
        data: { title: 'Doccure | Doctor | Profile-Settings' },
      },
      {
        path: 'social-media',
        component: SocialMediaComponent,
        data: { title: 'Doccure | Doctor | Social-Media' },
      },
      {
        path: 'change-password',
        component: ChangePasswordComponent,
        data: { title: 'Doccure | Doctor | Change-Password' },
      },
      {
        path: 'doctor-blog',
        component: DoctorBlogComponent,
        data: { title: 'Doccure | Doctor | Doctor-Blog' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DoctorRoutingModule {}
