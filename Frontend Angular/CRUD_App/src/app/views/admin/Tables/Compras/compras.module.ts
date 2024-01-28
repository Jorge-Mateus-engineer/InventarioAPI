import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComprasRoutingModule } from './compras-routing.module';
import { ComprasComponent } from './compras.component';
import { SharedModule } from 'src/app/views/shared/shared.module';

@NgModule({
  declarations: [ComprasComponent],
  imports: [CommonModule, ComprasRoutingModule, SharedModule],
})
export class ComprasModule {}
