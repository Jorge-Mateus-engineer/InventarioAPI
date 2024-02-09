import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { ProductoModel } from 'src/app/models/Productos/producto.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductosService extends BaseAPIService {
  baseEndpoint = 'api/Producto';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createProducto(productoModel: ProductoModel): Observable<ProductoModel> {
    return this.post<ProductoModel>(
      `${this.baseEndpoint}/Create`,
      productoModel,
      true
    );
  }

  getAllProductos(): Observable<Array<ProductoModel>> {
    return this.get<Array<ProductoModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      true
    );
  }

  updateProducto(productoModel: ProductoModel): Observable<ProductoModel> {
    return this.patch<ProductoModel>(
      `${this.baseEndpoint}/Update`,
      productoModel,
      true
    );
  }

  deleteProducto(productoModel: ProductoModel): Observable<ProductoModel> {
    return this.delete<ProductoModel>(
      `${this.baseEndpoint}/Delete`,
      productoModel.id_producto,
      true
    );
  }
}
