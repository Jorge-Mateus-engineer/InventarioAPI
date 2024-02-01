import { Component, OnInit } from '@angular/core';
import { ProductoModel } from 'src/app/models/Productos/producto.model';
import { ProductosService } from 'src/app/services/Productos/productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss'],
})
export class ProductosComponent implements OnInit {
  models: Array<ProductoModel> = [];

  productToEdit = new ProductoModel();
  productToDelete = new ProductoModel();
  productToCreate = new ProductoModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Producto',
      property: 'id_producto',
    },
    {
      header: 'Nombre del Producto',
      property: 'nombre',
    },
    {
      header: 'Descripción',
      property: 'descripcion',
    },
    {
      header: 'Id Categoria asociada',
      property: 'id_categoria',
    },
    {
      header: 'Unidad',
      property: 'unidad',
    },
    {
      header: 'Precio por unidad',
      property: 'precio_unitario',
    },
    {
      header: 'Id Proveedor Asociado',
      property: 'id_proveedor',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;

  constructor(private productosService: ProductosService) {}

  list(): void {
    this.productosService.getAllProductos().subscribe((p) => (this.models = p));
  }

  saveEditedProducto(confirmation: boolean): void {
    if (confirmation) {
      this.productosService
        .updateProducto(this.productToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createProducto(confirmation: boolean): void {
    if (confirmation) {
      this.productosService
        .createProducto(this.productToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteProducto(confirmation: boolean): void {
    if (confirmation) {
      this.productosService
        .deleteProducto(this.productToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
