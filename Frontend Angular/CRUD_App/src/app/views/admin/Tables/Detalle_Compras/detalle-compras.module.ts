import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DetalleComprasRoutingModule } from './detalle-compras-routing.module';
import { SharedModule } from 'src/app/views/shared/shared.module';
import { DetalleComprasComponent } from './detalle-compras.component';

@NgModule({
  declarations: [DetalleComprasComponent],
  imports: [CommonModule, DetalleComprasRoutingModule, SharedModule],
})
export class DetalleComprasModule {}
