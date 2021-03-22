import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorsRoutingModule } from './errors-routing.module';
import { ErrorsComponent } from './errors.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [ErrorsComponent, NotFoundComponent],
  imports: [
    CommonModule,
    ErrorsRoutingModule,
    RouterModule
  ]
})
export class ErrorsModule { }
