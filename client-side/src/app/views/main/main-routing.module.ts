import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthDoctorGuard } from 'src/app/shared/guards/auth-doctor.guard';
import { AuthPatientGuard } from 'src/app/shared/guards/auth-patient.guard';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { HomepageComponent } from './homepage/homepage.component';
import { MainComponent } from './main.component';
import { PrivacyPolicyComponent } from './privacy-policy/privacy-policy.component';
import { SearchDoctorsComponent } from './search-doctors/search-doctors.component';
import { TermsConditiosComponent } from './terms-conditios/terms-conditios.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: '', redirectTo: 'homepage' },
      {
        path: 'homepage',
        component: HomepageComponent,
        data: { title: 'Homepage' },
      },
      {
        path: 'doctor',
        loadChildren: () =>
          import('./doctor/doctor.module').then((x) => x.DoctorModule),
      },
      {
        path: 'patient',
        loadChildren: () =>
          import('./patient/patient.module').then((x) => x.PatientModule),
      },
      {
        path: 'blog',
        loadChildren: () =>
          import('./blog/blog.module').then((x) => x.BlogModule),
      },
      {
        path: 'doctor-profile/:slug',
        component: DoctorProfileComponent,
        data: { title: 'Doccure | Doctor-Profile' },
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard]
      },
      {
        path: 'search-doctors',
        component: SearchDoctorsComponent,
        data: { title: 'Doccure | Search-Doctors' },
      },
      {
        path: 'term-condition',
        component: TermsConditiosComponent,
        data: { title: 'Doccure | Term-Condition' },
      },
      {
        path: 'privacy-policy',
        component: PrivacyPolicyComponent,
        data: { title: 'Doccure | Privacy-Policy' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
