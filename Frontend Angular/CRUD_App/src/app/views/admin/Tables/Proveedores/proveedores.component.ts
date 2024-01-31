import { Component, OnInit } from '@angular/core';
import { ProveedorModel } from 'src/app/models/Proveedores/proveedor.model';
import { ProveedoresService } from 'src/app/services/Proveedores/proveedores.service';

@Component({
  selector: 'app-proveedores',
  templateUrl: './proveedores.component.html',
  styleUrls: ['./proveedores.component.scss'],
})
export class ProveedoresComponent implements OnInit {
  models: Array<ProveedorModel> = [];

  proveedorToEdit = new ProveedorModel();
  proveedorToDelete = new ProveedorModel();
  proveedorToCreate = new ProveedorModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Proveedor',
      property: 'id_proveedor',
    },
    {
      header: 'Nombre',
      property: 'nombre_proveedor',
    },
    {
      header: 'Empresa',
      property: 'nombre_empresa',
    },
    {
      header: 'Ciudad',
      property: 'ciudad',
    },
    {
      header: 'Dirección',
      property: 'direccion',
    },
    {
      header: 'Correo',
      property: 'email',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;

  constructor(private proveedorService: ProveedoresService) {}

  list(): void {
    this.proveedorService.listProveedores().subscribe((p) => (this.models = p));
  }

  saveEditedProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService
        .updateProveedor(this.proveedorToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService
        .createProveedor(this.proveedorToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService
        .deleteProveedor(this.proveedorToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
