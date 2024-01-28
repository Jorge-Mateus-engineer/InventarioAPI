import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientesRoutingModule } from './clientes-routing.module';
import { ClientesComponent } from './clientes.component';
import { SharedModule } from 'src/app/views/shared/shared.module';

@NgModule({
  declarations: [ClientesComponent],
  imports: [CommonModule, ClientesRoutingModule, SharedModule],
})
export class ClientesModule {}
