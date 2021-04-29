import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from './blog-routing.module';
import { BlogComponent } from './blog.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { RouterModule } from '@angular/router';
import { ComponentsHelperModule } from 'src/app/shared/components/components-helper.module';
import { UrlSanitizerPipe } from 'src/app/shared/pipes/url-sanitizer.pipe';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [BlogComponent, ListComponent, DetailsComponent, UrlSanitizerPipe],
  imports: [
    CommonModule,
    BlogRoutingModule,
    RouterModule,
    ComponentsHelperModule,
    PaginationModule.forRoot(),
  ],
  exports: [
    PaginationModule,
  ],
})
export class BlogModule { }
