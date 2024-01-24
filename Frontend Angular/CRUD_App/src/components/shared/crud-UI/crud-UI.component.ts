import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crud-UI',
  templateUrl: './crud-UI.component.html',
  styleUrls: ['./crud-UI.component.css'],
})
export class CrudUIComponent {
  @Input() tableName = '';

  constructor(private router: Router) {}

  actionList = [
    { text: `Lista de`, link: '' },
    { text: `Crear`, link: '' },
    { text: `Editar`, link: '/users/edit' },
    { text: `Eliminar`, link: '' },
  ];

  selectedAction: string | null = null;

  selectItem(action: string): void {
    this.selectedAction = action;
  }
}
