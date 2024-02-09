import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { DetalleCompraModel } from 'src/app/models/Detalle_Compras/detalleCompra.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DetalleComprasService extends BaseAPIService {
  baseEndpoint = 'api/DetalleCompra';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createDetalle(
    detalleCompraModel: DetalleCompraModel
  ): Observable<DetalleCompraModel> {
    return this.post<DetalleCompraModel>(
      `${this.baseEndpoint}/Create`,
      detalleCompraModel,
      true
    );
  }

  listDetalles(): Observable<Array<DetalleCompraModel>> {
    return this.get<Array<DetalleCompraModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      true
    );
  }

  listDetallesByPurchaseId(id: Number): Observable<Array<DetalleCompraModel>> {
    return this.get<Array<DetalleCompraModel>>(
      `${this.baseEndpoint}/GetAll`,
      `?purchaseId=${id}`,
      true
    );
  }

  updateDetalle(
    detalleCompraModel: DetalleCompraModel
  ): Observable<DetalleCompraModel> {
    return this.patch<DetalleCompraModel>(
      `${this.baseEndpoint}/Update`,
      detalleCompraModel,
      true
    );
  }

  deleteDetalle(
    detalleCompraModel: DetalleCompraModel
  ): Observable<DetalleCompraModel> {
    return this.delete<DetalleCompraModel>(
      `${this.baseEndpoint}/Delete`,
      detalleCompraModel.id_detalle_compra,
      true
    );
  }
}
