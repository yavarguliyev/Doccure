import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthPatientGuard } from 'src/app/shared/guards/auth-patient.guard';
import { BookingSuccessComponent } from './booking-success/booking-success.component';
import { BookingComponent } from './booking/booking.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DoctorsLocationComponent } from './doctors-location/doctors-location.component';
import { FavouriteDoctorsComponent } from './favourite-doctors/favourite-doctors.component';
import { MessagesComponent } from './messages/messages.component';
import { PatientComponent } from './patient.component';
import { ProfileSettingsComponent } from './profile-settings/profile-settings.component';

const routes: Routes = [
  {
    path: '',
    component: PatientComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthPatientGuard],
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        data: { title: 'Doccure | Patient | Dashboard' },
      },
      {
        path: 'booking/:slug',
        component: BookingComponent,
        data: { title: 'Doccure | Patient | Booking' },
      },
      {
        path: 'checkout/:token',
        component: BookingSuccessComponent,
        data: { title: 'Patient | Doctor | Checkout' },
      },
      {
        path: 'booking-success/:number',
        component: BookingSuccessComponent,
        data: { title: 'Doccure | Patient | Booking-Success' },
      },
      {
        path: 'messages',
        component: MessagesComponent,
        data: { title: 'Doccure | Patient | Messages' },
      },
      {
        path: 'profile-settings',
        component: ProfileSettingsComponent,
        data: { title: 'Doccure | Patient | Profile-settings' },
      },
      {
        path: 'change-password',
        component: ChangePasswordComponent,
        data: { title: 'Doccure | Patient | Change-Password' },
      },
      {
        path: 'doctors-location',
        component: DoctorsLocationComponent,
        data: { title: 'Doccure | Patient | Doctors-Location' },
      },
      {
        path: 'favourite-doctors',
        component: FavouriteDoctorsComponent,
        data: { title: 'Doccure | Patient | Favourite-Doctors' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PatientRoutingModule {}
