import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriasRoutingModule } from './categorias-routing.module';
import { CategoriasComponent } from './categorias.component';
import { SharedModule } from 'src/app/views/shared/shared.module';

@NgModule({
  declarations: [CategoriasComponent],
  imports: [CommonModule, CategoriasRoutingModule, SharedModule],
})
export class CategoriasModule {}
