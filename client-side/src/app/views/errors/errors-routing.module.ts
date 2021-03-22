import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorsComponent } from './errors.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    component: ErrorsComponent,
    children: [
      { path: '', redirectTo: 'not-found' },
      { path: 'not-found', component: NotFoundComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ErrorsRoutingModule { }
