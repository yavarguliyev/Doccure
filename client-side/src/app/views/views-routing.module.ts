import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewsComponent } from './views.component';

const routes: Routes = [
  {
    path: '', component: ViewsComponent,
    children: [
      { path: '', loadChildren: () => import('./main/main.module').then(x => x.MainModule) },
      { path: 'main', loadChildren: () => import('./main/main.module').then(x => x.MainModule) },
      { path: 'auth', loadChildren: () => import('./auth/auth.module').then(x => x.AuthModule) },
      { path: 'admin', loadChildren: () => import('./admin/admin.module').then(x => x.AdminModule) },
      { path: 'errors', loadChildren: () => import('./errors/errors.module').then(x => x.ErrorsModule) },
      { path: '**', redirectTo: '/errors/not-found' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewsRoutingModule { }
