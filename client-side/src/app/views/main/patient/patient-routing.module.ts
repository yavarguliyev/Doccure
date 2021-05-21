import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'booking/:slug', component: BookingComponent },
      { path: 'checkout/:token', component: BookingSuccessComponent },
      { path: 'booking-success/:number', component: BookingSuccessComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'profile-settings', component: ProfileSettingsComponent },
      { path: 'change-password', component: ChangePasswordComponent },
      { path: 'doctors-location', component: DoctorsLocationComponent },
      { path: 'favourite-doctors', component: FavouriteDoctorsComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
