import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BodegaModel } from 'src/app/models/Bodegas/bodega.model';
import { BodegasService } from 'src/app/services/Bodegas/bodegas.service';

@Component({
  selector: 'app-bodegas',
  templateUrl: './bodegas.component.html',
  styleUrls: ['./bodegas.component.scss'],
})
export class BodegasComponent implements OnInit {
  models: Array<BodegaModel> = [];

  bodegaToEdit = new BodegaModel();
  bodegaToDelete = new BodegaModel();
  bodegaToCreate = new BodegaModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Bodega',
      property: 'id_bodega',
    },
    {
      header: 'Nombre',
      property: 'nombre',
    },
    {
      header: 'Hora de apertura',
      property: 'hora_de_apertura',
    },
    {
      header: 'Hora de cierre',
      property: 'hora_de_cierre',
    },
    {
      header: 'Dirección',
      property: 'direccion',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;
  showErrorOverlay: boolean = false;

  errorCode: String = '';
  errorMessage: String = '';

  constructor(private bodegaService: BodegasService) {}

  handleError(error: HttpErrorResponse): void {
    this.showErrorOverlay = true;
    this.errorCode = error.status.toString();
    this.errorMessage = error.statusText;
  }

  list(): void {
    this.bodegaService.listBodegas().subscribe(
      (b) => (this.models = b),
      (error) => this.handleError(error)
    );
  }

  saveEditedBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService.editBodega(this.bodegaToEdit).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  createBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService.createBodega(this.bodegaToCreate).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  deleteBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService.deleteBodega(this.bodegaToDelete).subscribe({
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
