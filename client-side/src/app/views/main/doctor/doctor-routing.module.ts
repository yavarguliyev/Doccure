import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthDoctorGuard } from 'src/app/shared/guards/auth-doctor.guard';
import { AppointmentsComponent } from './appointments/appointments.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DoctorBlogComponent } from './doctor-blog/doctor-blog.component';
import { DoctorComponent } from './doctor.component';
import { InvoicesDetailsComponent } from './invoices-details/invoices-details.component';
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
      { path: 'dashboard', component: DashboardComponent },
      { path: 'appointments', component: AppointmentsComponent },
      { path: 'my-patients', component: MyPatientsComponent },
      { path: 'patient-profile/:slug', component: PatientProfileComponent },
      { path: 'schedule-timings', component: ScheduleTimingsComponent },
      { path: 'invoices', component: InvoicesComponent },
      { path: 'invoices/:id', component: InvoicesDetailsComponent },
      { path: 'reviews', component: ReviewsComponent },
      { path: 'message', component: MessagesComponent },
      { path: 'profile-settings', component: ProfileSettingsComponent },
      { path: 'social-media', component: SocialMediaComponent },
      { path: 'change-password', component: ChangePasswordComponent },
      { path: 'doctor-blog', component: DoctorBlogComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
