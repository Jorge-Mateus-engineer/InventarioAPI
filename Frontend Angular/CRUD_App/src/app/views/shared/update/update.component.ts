import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss'],
  host: {
    '(document:keydown.escape)': 'handleKeyboardEvent($event)',
  },
})
export class UpdateComponent {
  @Input() headersAndProperties: any[] = [];
  @Input() modelToEdit: any;

  @Output() emitModelToEdit = new EventEmitter<any>();
  @Output() emitEdit = new EventEmitter<boolean>();
  @Output() emitCloseOverlay = new EventEmitter<boolean>();

  closeOverlay(): void {
    this.emitCloseOverlay.emit(false);
  }

  handleKeyboardEvent(event: KeyboardEvent) {
    this.closeOverlay();
  }

  saveForm(): void {
    this.emitModelToEdit.emit(this.modelToEdit);
    this.emitEdit.emit(true);
  }
}
