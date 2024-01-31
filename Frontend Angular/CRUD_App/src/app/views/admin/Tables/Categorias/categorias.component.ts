import { Component, OnInit } from '@angular/core';
import { CategoriaModel } from 'src/app/models/Categorias/categoria.model';
import { CategoriasService } from 'src/app/services/Categorias/categorias.service';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.scss'],
})
export class CategoriasComponent implements OnInit {
  models: Array<CategoriaModel> = [];

  categoriaToEdit = new CategoriaModel();
  categoriaToDelete = new CategoriaModel();
  categoriaToCreate = new CategoriaModel();

  headersAndProperties: any[] = [
    {
      header: 'Id Categoria',
      property: 'id_categoria',
    },
    {
      header: 'Nombre',
      property: 'nombre',
    },
    {
      header: 'Descripcion',
      property: 'descripcion',
    },
  ];

  showEditOverlay: boolean = false;
  showDeleteOverlay: boolean = false;
  showCreateOverlay: boolean = false;

  constructor(private categoriaService: CategoriasService) {}

  list(): void {
    this.categoriaService.listCategorias().subscribe(
      (c) => (this.models = c),
      (error) => {
        console.error('Error fetching', error);
      }
    );
  }

  saveEditedCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService
        .updateCategoria(this.categoriaToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  createCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService
        .createCategoria(this.categoriaToCreate)
        .subscribe((val) => console.log(val));
    }
  }

  deleteCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService
        .deleteCategoria(this.categoriaToDelete)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}
