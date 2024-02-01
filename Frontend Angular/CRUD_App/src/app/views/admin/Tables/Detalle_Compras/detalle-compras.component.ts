import { HttpErrorResponse } from '@angular/common/http';
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
  showErrorOverlay: boolean = false;

  errorCode: String = '';
  errorMessage: String = '';

  constructor(private detalleComprasService: DetalleComprasService) {}

  handleError(error: HttpErrorResponse): void {
    this.showErrorOverlay = true;
    this.errorCode = error.status.toString();
    this.errorMessage = error.statusText;
  }

  list(): void {
    this.detalleComprasService.listDetalles().subscribe(
      (d) => (this.models = d),
      (error) => this.handleError(error)
    );
  }

  saveEditedDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService.updateDetalle(this.detalleToEdit).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  createDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService.createDetalle(this.detalleToCreate).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  deleteDetalle(confirmation: boolean): void {
    if (confirmation) {
      this.detalleComprasService.deleteDetalle(this.detalleToDelete).subscribe({
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
