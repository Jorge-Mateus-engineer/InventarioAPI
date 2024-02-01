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

  constructor(private disponibilidadService: DisponibilidadService) {}

  list(): void {
    this.disponibilidadService
      .getAllDisponibilidad()
      .subscribe((d) => (this.models = d));
  }

  saveEditedDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .updateDisponibilidad(this.disponibilidadToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .createDisponibilidad(this.disponibilidadToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteDisponibilidad(confirmation: boolean): void {
    if (confirmation) {
      this.disponibilidadService
        .deleteDisponibilidad(this.disponibilidadToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
