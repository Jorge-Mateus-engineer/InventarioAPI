import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss'],
})
export class ErrorComponent {
  @Input() errorCode: String = '';
  @Input() errorMessage: String = '';
  @Output() emitCloseOverlay = new EventEmitter<boolean>();

  closeOverlay(): void {
    this.emitCloseOverlay.emit(false);
  }
}
