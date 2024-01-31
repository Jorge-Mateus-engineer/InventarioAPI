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

  constructor(private bodegaService: BodegasService) {}

  list(): void {
    this.bodegaService.listBodegas().subscribe(
      (b) => (this.models = b),
      (error) => {
        console.error('Error fetching', error);
      }
    );
  }

  saveEditedBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService
        .editBodega(this.bodegaToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService
        .createBodega(this.bodegaToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteBodega(confirmation: boolean): void {
    if (confirmation) {
      this.bodegaService
        .deleteBodega(this.bodegaToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
