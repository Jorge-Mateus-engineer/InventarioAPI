import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DisponibilidadRoutingModule } from './disponibilidad-routing.module';
import { DisponibilidadComponent } from './disponibilidad.component';
import { SharedModule } from 'src/app/views/shared/shared.module';

@NgModule({
  declarations: [DisponibilidadComponent],
  imports: [CommonModule, DisponibilidadRoutingModule, SharedModule],
})
export class DisponibilidadModule {}
