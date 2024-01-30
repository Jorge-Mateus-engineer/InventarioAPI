import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { CategoriaModel } from 'src/app/models/Categorias/categoria.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoriasService extends BaseAPIService {
  baseEndpoint = 'api/Categoria';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createCategoria(categoriaModel: CategoriaModel): Observable<CategoriaModel> {
    return this.post<CategoriaModel>(
      `${this.baseEndpoint}/Create`,
      categoriaModel,
      true
    );
  }

  listCategorias(): Observable<Array<CategoriaModel>> {
    return this.get<Array<CategoriaModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      false
    );
  }

  updateCategoria(categoriaModel: CategoriaModel): Observable<CategoriaModel> {
    return this.patch<CategoriaModel>(
      `${this.baseEndpoint}/Update`,
      categoriaModel,
      true
    );
  }

  deleteCategoria(categoriaModel: CategoriaModel): Observable<CategoriaModel> {
    return this.delete<CategoriaModel>(
      `${this.baseEndpoint}/Delete`,
      categoriaModel.id_categoria,
      true
    );
  }
}
