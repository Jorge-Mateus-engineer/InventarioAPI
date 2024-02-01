import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DisponibilidadModel } from 'src/app/models/Disponibilidad/disponibilidad.model';
import { DisponibilidadService } from 'src/app/services/Disponibilidad/disponibilidad.service';

@Component({
  selector: 'app-disponibilidad',
  templateUrl: './disponibilidad.component.html',
  styleUrls: ['./disponibilidad.component.scss'],
})
export class DisponibilidadComponent implements OnInit {
  models: Array<DisponibilidadModel> = [];

  disponibilidadToEdit = new DisponibilidadModel();
  disponibilidadToDelete = new DisponibilidadModel();
  disponibilidadToCreate = new DisponibilidadModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Producto',
      property: 'id_producto',
    },
    {
      header: 'Id Bodega',
      property: 'id_bodega',
    },
    {
      header: 'Unidad',
      property: 'unidad',
    },
    {
      header: 'Unidades en stock',
      property: 'unidades_disponibles',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;
  showErrorOverlay: boolean = false;

  errorCode: String = '';
  errorMessage: String = '';

  constructor(private disponibilidadService: DisponibilidadService) {}

  handleError(error: HttpErrorResponse): void {
    this.showErrorOverlay = true;
    this.errorCode = error.status.toString();
    this.errorMessage = error.statusText;
  }

  list(): void {
    this.disponibilidadService.getAllDisponibilidad().subscribe(
      (d) => (this.models = d),
      (error) => this.handleError(error)
    );
  }

  saveEditedDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .updateDisponibilidad(this.disponibilidadToEdit)
        .subscribe({
          error: (error) => {
            this.handleError(error);
          },
        });
    }
  }

  createDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .createDisponibilidad(this.disponibilidadToCreate)
        .subscribe({
          error: (error) => {
            this.handleError(error);
          },
        });
    }
  }

  deleteDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .deleteDisponibilidad(this.disponibilidadToDelete)
        .subscribe({
          error: (error) => {
            this.handleError(error);
          },
        });
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
