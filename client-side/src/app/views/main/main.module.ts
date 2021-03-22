import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { MainComponent } from './main.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LayoutMainModule } from 'src/app/shared/main-containers/layout/layoutmain.module';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';

@NgModule({
  declarations: [MainComponent, HomepageComponent],
  imports: [
    CommonModule,
    MainRoutingModule,
    LayoutMainModule,
    ComponentsHelperModule
  ],
})
export class MainModule { }
