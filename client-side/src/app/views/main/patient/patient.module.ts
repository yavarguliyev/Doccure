import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { PatientComponent } from './patient.component';
import { DoctorsLocationComponent } from './doctors-location/doctors-location.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BookingComponent } from './booking/booking.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { BookingSuccessComponent } from './booking-success/booking-success.component';
import { FavouriteDoctorsComponent } from './favourite-doctors/favourite-doctors.component';
import { MessagesComponent } from './messages/messages.component';
import { ProfileSettingsComponent } from './profile-settings/profile-settings.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';


@NgModule({
  declarations: [
    PatientComponent,
    DoctorsLocationComponent,
    DashboardComponent,
    BookingComponent,
    CheckoutComponent,
    BookingSuccessComponent,
    FavouriteDoctorsComponent,
    MessagesComponent,
    ProfileSettingsComponent,
    ChangePasswordComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule,
    ComponentsHelperModule,
  ]
})
export class PatientModule { }
