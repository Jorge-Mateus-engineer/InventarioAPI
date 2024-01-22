import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

/*Component imports */
import { AuthenticationComponent } from 'src/components/shared/authentication/authentication.component';
import { UsersComponent } from 'src/components/Users/Users.component';
import { ProductsComponent } from 'src/components/Products/Products.component';

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
    component: UsersComponent,
  },
  { path: 'products', component: ProductsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
