import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent {
  @Input() headersAndPropList: any[] = [];
  @Input() modelToCreate: any;

  @Output() emitCloseOverlay = new EventEmitter<boolean>();
  @Output() emitModel = new EventEmitter<any>();
  @Output() emitConfirmation = new EventEmitter<boolean>();

  confirmCreation(): void {
    console.log(this.modelToCreate);
    this.emitConfirmation.emit(true);
    this.emitModel.emit(this.modelToCreate);
    this.closeOverlay();
    setTimeout(() => window.location.reload(), 1000);
  }

  closeOverlay(): void {
    this.emitCloseOverlay.emit(false);
  }
}
