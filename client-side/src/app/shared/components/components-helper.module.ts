import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecialitiesComponent } from './specialities/specialities.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [SpecialitiesComponent],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    SpecialitiesComponent
  ]
})
export class ComponentsHelperModule { }
