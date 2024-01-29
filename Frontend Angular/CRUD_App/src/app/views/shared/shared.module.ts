import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { UpdateComponent } from './update/update.component';

@NgModule({
  declarations: [ListComponent, UpdateComponent],
  imports: [CommonModule, MatTableModule, MatSortModule, MatButtonModule],
  exports: [ListComponent, UpdateComponent, MatTableModule, MatSortModule],
})
export class SharedModule {}
