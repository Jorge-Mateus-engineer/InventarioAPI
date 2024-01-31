import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { ProveedorModel } from 'src/app/models/Proveedores/proveedor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProveedoresService extends BaseAPIService {
  baseEndpoint = 'api/Proveedor';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createProveedor(proveedorModel: ProveedorModel): Observable<ProveedorModel> {
    return this.post<ProveedorModel>(
      `${this.baseEndpoint}/Create`,
      proveedorModel,
      true
    );
  }

  listProveedores(): Observable<Array<ProveedorModel>> {
    return this.get<Array<ProveedorModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      true
    );
  }

  updateProveedor(proveedorModel: ProveedorModel): Observable<ProveedorModel> {
    return this.patch<ProveedorModel>(
      `${this.baseEndpoint}/Update`,
      proveedorModel,
      true
    );
  }

  deleteProveedor(proveedorModel: ProveedorModel): Observable<ProveedorModel> {
    return this.delete<ProveedorModel>(
      `${this.baseEndpoint}/Delete`,
      proveedorModel.id_proveedor,
      true
    );
  }
}
