import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
      { path: 'homepage', component: HomepageComponent },
      {
        path: 'doctor',
        loadChildren: () =>
          import('./doctor/doctor.module').then((x) => x.DoctorModule),
      },
      {
        path: 'blog',
        loadChildren: () =>
          import('./blog/blog.module').then((x) => x.BlogModule),
      },
      { path: 'search-doctors', component: SearchDoctorsComponent },
      { path: 'term-condition', component: TermsConditiosComponent },
      { path: 'privacy-policy', component: PrivacyPolicyComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
