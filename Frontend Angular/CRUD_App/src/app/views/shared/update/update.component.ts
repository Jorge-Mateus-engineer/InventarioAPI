import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss'],
})
export class UpdateComponent {
  @Input() headersAndProperties: any[] = [];
  @Input() modelToEdit: any;

  @Output() emitModelToEdit = new EventEmitter<any>();
  @Output() emitEdit = new EventEmitter<boolean>();

  saveForm(): void {
    this.emitModelToEdit.emit(this.modelToEdit);
    this.emitEdit.emit(true);
  }
}
