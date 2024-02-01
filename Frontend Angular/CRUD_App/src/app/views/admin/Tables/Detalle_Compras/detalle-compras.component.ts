import { Component, OnInit } from '@angular/core';
import { DetalleCompraModel } from 'src/app/models/Detalle_Compras/detalleCompra.model';
import { DetalleComprasService } from 'src/app/services/Detalle_compras/detalle-compras.service';

@Component({
  selector: 'app-detalle-compras',
  templateUrl: './detalle-compras.component.html',
  styleUrls: ['./detalle-compras.component.scss'],
})
export class DetalleComprasComponent implements OnInit {
  models: Array<DetalleCompraModel> = [];

  detalleToEdit = new DetalleCompraModel();
  detalleToDelete = new DetalleCompraModel();
  detalleToCreate = new DetalleCompraModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Detalle',
      property: 'id_detalle_compra',
    },
    {
      header: 'Id Producto asociado',
      property: 'id_producto',
    },
    {
      header: 'Cantidad del producto',
      property: 'cantidad',
    },
    {
      header: 'Id CompraAsociada',
      property: 'id_compra',
    },
    {
      header: 'Total',
      property: 'total_detalle',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;

  constructor(private detalleComprasService: DetalleComprasService) {}

  list(): void {
    this.detalleComprasService
      .listDetalles()
      .subscribe((d) => (this.models = d));
  }

  saveEditedDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService
        .updateDetalle(this.detalleToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService
        .createDetalle(this.detalleToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService
        .deleteDetalle(this.detalleToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
