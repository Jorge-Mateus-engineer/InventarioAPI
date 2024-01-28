import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationComponent } from './layouts/authentication/authentication.component';
import { AdminComponent } from './layouts/admin/admin.component';

/*Component imports */

const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full',
  },
  {
    path: 'auth',
    component: AuthenticationComponent,
    children: [
      {
        path: 'login',
        loadChildren: () =>
          import('./views/authentication/login/login.module').then(
            (m) => m.LoginModule
          ),
      },
      {
        path: 'register',
        loadChildren: () =>
          import('./views/authentication/register/register.module').then(
            (m) => m.RegisterModule
          ),
      },
    ],
  },
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      {
        path: 'home',
        loadChildren: () =>
          import('./views/admin/home/home.module').then((m) => m.HomeModule),
      },
      {
        path: 'profile',
        loadChildren: () =>
          import('./views/admin/profile/profile.module').then(
            (m) => m.ProfileModule
          ),
      },
      {
        path: 'table',
        loadChildren: () =>
          import('./views/admin/table/table.module').then((m) => m.TableModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
