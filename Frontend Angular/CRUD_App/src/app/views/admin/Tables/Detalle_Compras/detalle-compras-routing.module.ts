import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleComprasComponent } from './detalle-compras.component';

const routes: Routes = [
  {
    path: '',
    component: DetalleComprasComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DetalleComprasRoutingModule {}
