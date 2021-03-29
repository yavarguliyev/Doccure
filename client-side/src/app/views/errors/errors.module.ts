import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorsRoutingModule } from './errors-routing.module';
import { ErrorsComponent } from './errors.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RouterModule } from '@angular/router';
import { ServerErrorComponent } from './server-error/server-error.component';


@NgModule({
  declarations: [ErrorsComponent, NotFoundComponent, ServerErrorComponent],
  imports: [
    CommonModule,
    ErrorsRoutingModule,
    RouterModule
  ]
})
export class ErrorsModule { }
