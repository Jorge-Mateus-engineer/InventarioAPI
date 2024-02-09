import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { CompraModel } from 'src/app/models/Compras/compra.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ComprasService extends BaseAPIService {
  baseEndpoint = 'api/Compra';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createCompra(compraModel: CompraModel): Observable<CompraModel> {
    return this.post<CompraModel>(
      `${this.baseEndpoint}/Create`,
      compraModel,
      true
    );
  }

  listCompra(): Observable<Array<CompraModel>> {
    return this.get<Array<CompraModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      true
    );
  }

  listCompraByClientId(id: Number): Observable<Array<CompraModel>> {
    return this.get<Array<CompraModel>>(
      `${this.baseEndpoint}/GetByClientId`,
      `?id=${id}`,
      true
    );
  }

  updateCompra(compraModel: CompraModel): Observable<CompraModel> {
    return this.patch<CompraModel>(
      `${this.baseEndpoint}/Update`,
      compraModel,
      true
    );
  }

  deleteCompra(compraModel: CompraModel): Observable<CompraModel> {
    return this.delete<CompraModel>(
      `${this.baseEndpoint}/Delete`,
      compraModel.id_compra,
      true
    );
  }
}
