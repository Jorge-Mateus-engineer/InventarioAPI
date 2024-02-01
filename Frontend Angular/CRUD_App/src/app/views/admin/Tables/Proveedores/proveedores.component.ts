import { HttpErrorResponse } from '@angular/common/http';
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
  showErrorOverlay: boolean = false;

  errorCode: String = '';
  errorMessage: String = '';

  constructor(private proveedorService: ProveedoresService) {}

  handleError(error: HttpErrorResponse): void {
    this.showErrorOverlay = true;
    this.errorCode = error.status.toString();
    this.errorMessage = error.statusText;
  }

  list(): void {
    this.proveedorService.listProveedores().subscribe(
      (p) => (this.models = p),
      (error) => this.handleError(error)
    );
  }

  saveEditedProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService.updateProveedor(this.proveedorToEdit).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  createProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService.createProveedor(this.proveedorToCreate).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  deleteProveedor(confirmation: boolean): void {
    if (confirmation) {
      this.proveedorService.deleteProveedor(this.proveedorToDelete).subscribe({
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
