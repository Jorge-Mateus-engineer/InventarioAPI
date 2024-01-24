import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

/*Component imports */
import { AuthenticationComponent } from 'src/components/shared/authentication/authentication.component';
import { UsersComponent } from 'src/components/Users/Users.component';
import { ProductsComponent } from 'src/components/Products/Products.component';
import { ListUsersComponent } from 'src/components/Users/list-users/list-users.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: AuthenticationComponent,
  },
  {
    path: 'users',
    children: [
      { path: '', component: UsersComponent },
      { path: 'edit', component: ListUsersComponent },
    ],
  },
  { path: 'products', component: ProductsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
