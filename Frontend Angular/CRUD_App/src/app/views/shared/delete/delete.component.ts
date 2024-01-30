import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss'],
  host: {
    '(document:keydown.escape)': 'handleKeyboardEvent($event)',
  },
})
export class DeleteComponent {
  @Input() headersAndProperties: any[] = [];
  @Input() modelToDelete: any;

  @Output() emitModelToDelete = new EventEmitter<any>();
  @Output() emitDeleteConfirmation = new EventEmitter<boolean>();
  @Output() emitCloseOverlay = new EventEmitter<boolean>();

  constructor(private router: Router) {}

  closeOverlay(): void {
    this.emitCloseOverlay.emit(false);
  }

  handleKeyboardEvent(event: KeyboardEvent) {
    this.closeOverlay();
  }

  confirmDelete(): void {
    this.emitModelToDelete.emit(this.modelToDelete);
    this.emitDeleteConfirmation.emit(true);
    this.closeOverlay();
    this.router.navigateByUrl(this.router.url);
  }
}
