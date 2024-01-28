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
        path: 'bodegas',
        loadChildren: () =>
          import('./views/admin/Tables/Bodegas/bodegas.module').then(
            (m) => m.BodegasModule
          ),
      },
      {
        path: 'categorias',
        loadChildren: () =>
          import('./views/admin/Tables/Categorias/categorias.module').then(
            (m) => m.CategoriasModule
          ),
      },
      {
        path: 'clientes',
        loadChildren: () =>
          import('./views/admin/Tables/Clientes/clientes.module').then(
            (m) => m.ClientesModule
          ),
      },
      {
        path: 'compras',
        loadChildren: () =>
          import('./views/admin/Tables/Compras/compras.module').then(
            (m) => m.ComprasModule
          ),
      },
      {
        path: 'detalleCompras',
        loadChildren: () =>
          import(
            './views/admin/Tables/Detalle_Compras/detalle-compras.module'
          ).then((m) => m.DetalleComprasModule),
      },
      {
        path: 'disponibilidad',
        loadChildren: () =>
          import(
            './views/admin/Tables/Disponibilidad/disponibilidad.module'
          ).then((m) => m.DisponibilidadModule),
      },
      {
        path: 'productos',
        loadChildren: () =>
          import('./views/admin/Tables/Productos/productos.module').then(
            (m) => m.ProductosModule
          ),
      },
      {
        path: 'proveedores',
        loadChildren: () =>
          import('./views/admin/Tables/Proveedores/proveedores.module').then(
            (m) => m.ProveedoresModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
