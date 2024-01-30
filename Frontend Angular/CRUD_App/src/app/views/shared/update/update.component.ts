import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss'],
  host: {
    '(document:keydown.escape)': 'handleKeyboardEvent($event)',
  },
})
export class UpdateComponent implements OnInit {
  @Input() headersAndProperties: any[] = [];
  @Input() modelToEdit: any;

  @Output() emitModelToEdit = new EventEmitter<any>();
  @Output() emitEditConfirmation = new EventEmitter<boolean>();
  @Output() emitCloseOverlay = new EventEmitter<boolean>();

  originalModel: any;

  constructor(private router: Router) {}

  ngOnInit(): void {
    // Initialize originalModel when modelToEdit is available
    if (this.modelToEdit) {
      this.originalModel = { ...this.modelToEdit };
    }
  }

  closeOverlay(): void {
    this.emitCloseOverlay.emit(false);
  }

  handleKeyboardEvent(event: KeyboardEvent) {
    this.closeOverlay();
  }

  saveForm(): void {
    this.emitModelToEdit.emit(this.modelToEdit);
    this.emitEditConfirmation.emit(true);
    this.closeOverlay();
    this.router.navigateByUrl(this.router.url);
  }
}
