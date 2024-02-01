import { HttpErrorResponse } from '@angular/common/http';
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
  showErrorOverlay: boolean = false;

  errorCode: String = '';
  errorMessage: String = '';

  constructor(private categoriaService: CategoriasService) {}

  handleError(error: HttpErrorResponse): void {
    this.showErrorOverlay = true;
    this.errorCode = error.status.toString();
    this.errorMessage = error.statusText;
  }

  list(): void {
    this.categoriaService.listCategorias().subscribe(
      (c) => (this.models = c),
      (error) => this.handleError(error)
    );
  }

  saveEditedCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService.updateCategoria(this.categoriaToEdit).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  createCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService.createCategoria(this.categoriaToCreate).subscribe({
        error: (error) => {
          this.handleError(error);
        },
      });
    }
  }

  deleteCategoria(confirmation: boolean): void {
    if (confirmation) {
      this.categoriaService.deleteCategoria(this.categoriaToDelete).subscribe({
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
