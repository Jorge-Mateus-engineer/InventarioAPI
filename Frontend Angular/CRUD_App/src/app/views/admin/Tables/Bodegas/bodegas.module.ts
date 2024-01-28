import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BodegasRoutingModule } from './bodegas-routing.module';
import { BodegasComponent } from './bodegas.component';
import { SharedModule } from 'src/app/views/shared/shared.module';

@NgModule({
  declarations: [BodegasComponent],
  imports: [CommonModule, BodegasRoutingModule, SharedModule],
})
export class BodegasModule {}
