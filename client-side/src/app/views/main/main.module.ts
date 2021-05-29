import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { MainComponent } from './main.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';
import { TermsConditiosComponent } from './terms-conditios/terms-conditios.component';
import { PrivacyPolicyComponent } from './privacy-policy/privacy-policy.component';
import { LayoutMainModule } from 'src/app/shared/containers/main-containers/layout/layoutmain.module';
import { SearchDoctorsComponent } from './search-doctors/search-doctors.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';

@NgModule({
  declarations: [
    MainComponent,
    HomepageComponent,
    TermsConditiosComponent,
    PrivacyPolicyComponent,
    SearchDoctorsComponent,
    DoctorProfileComponent,
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    LayoutMainModule,
    ComponentsHelperModule,
  ],
})
export class MainModule {}
