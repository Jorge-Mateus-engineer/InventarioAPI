import {
  Component,
  Input,
  OnChanges,
  SimpleChanges,
  Output,
  EventEmitter,
} from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnChanges {
  /*Getting Data from parent component */
  /**
   *Array of models used to populate table rows
   *
   * @type {any[]}
   * @memberof ListComponent
   */
  @Input() modelsList: any[] = [];
  /**
   * Array of objects of the schema { header: 'string' , property: 'string'}
   * used to populate column tittles and acces the model's preperty using array notation model[property]
   * @type {any[]}
   * @memberof ListComponent
   */
  @Input() headersAndPropList: any[] = [];
  /**
   *Array of strings used to render column tittles
   *
   * @type {string[]}
   * @memberof ListComponent
   */
  displayedColumns: string[] = [];

  /*Sending data to parent component */
  @Output() emitModelToEdit = new EventEmitter<any>();
  @Output() emitModelToDelete = new EventEmitter<any>();
  @Output() emitEditOverlay = new EventEmitter<boolean>();
  @Output() emitDeleteOverlay = new EventEmitter<boolean>();
  @Output() emitCreateOverlay = new EventEmitter<boolean>();

  sendToParentForEdit(model: any): void {
    this.emitModelToEdit.emit(model);
    this.emitEditOverlay.emit(true);
  }

  sendToParenForDeleting(model: any): void {
    this.emitModelToDelete.emit(model);
    this.emitDeleteOverlay.emit(true);
  }

  openCreateOverlay(): void {
    this.emitCreateOverlay.emit(true);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['headersAndPropList']) {
      this.displayedColumns = this.headersAndPropList.map(
        (prop) => prop.property
      );
      this.displayedColumns.push('acciones');
    }
  }
}
