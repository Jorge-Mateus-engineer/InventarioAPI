import { Component, OnInit } from '@angular/core';
import { CompraModel } from 'src/app/models/Compras/compra.model';
import { ComprasService } from 'src/app/services/Compras/compras.service';

@Component({
  selector: 'app-compras',
  templateUrl: './compras.component.html',
  styleUrls: ['./compras.component.scss'],
})
export class ComprasComponent implements OnInit {
  models: Array<CompraModel> = [];

  compraToEdit = new CompraModel();
  compraToDelete = new CompraModel();
  compraToCreate = new CompraModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Compra',
      property: 'id_compra',
    },
    {
      header: 'Id Cliente Asociado',
      property: 'id_cliente',
    },
    {
      header: 'Total de la compra',
      property: 'valor_total',
    },
    {
      header: 'Hora de la Compra',
      property: 'hora_de_compra',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;

  constructor(private compraService: ComprasService) {}

  list(): void {
    this.compraService.listCompra().subscribe((c) => (this.models = c));
  }

  saveEditedCompra(confirmation: boolean): void {
    if (confirmation) {
      this.compraService
        .updateCompra(this.compraToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createCompra(confirmation: boolean): void {
    if (confirmation) {
      this.compraService
        .createCompra(this.compraToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteCompra(confirmation: boolean): void {
    if (confirmation) {
      this.compraService
        .deleteCompra(this.compraToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
