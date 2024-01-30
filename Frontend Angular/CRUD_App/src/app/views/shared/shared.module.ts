import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { UpdateComponent } from './update/update.component';
import { ReadComponent } from './read/read.component';
import { DeleteComponent } from './delete/delete.component';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    ListComponent,
    UpdateComponent,
    ReadComponent,
    DeleteComponent,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
  ],
  exports: [
    ListComponent,
    UpdateComponent,
    ReadComponent,
    DeleteComponent,
    MatTableModule,
    MatSortModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
  ],
})
export class SharedModule {}
