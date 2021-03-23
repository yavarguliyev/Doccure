import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from './blog-routing.module';
import { BlogComponent } from './blog.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { RouterModule } from '@angular/router';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';


@NgModule({
  declarations: [BlogComponent, ListComponent, DetailsComponent],
  imports: [
    CommonModule,
    BlogRoutingModule,
    RouterModule,
    ComponentsHelperModule
  ]
})
export class BlogModule { }
