import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { BodegaModel } from 'src/app/models/Bodegas/bodega.model';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BodegasService extends BaseAPIService {
  baseEndpoint = 'api/Bodega';
  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createBodega(bodegaModel: BodegaModel): Observable<BodegaModel> {
    return this.post<BodegaModel>(
      `${this.baseEndpoint}/Create`,
      bodegaModel,
      true
    );
  }

  listBodegas(): Observable<Array<BodegaModel>> {
    return this.get<Array<BodegaModel>>(
      `${this.baseEndpoint}/GetAll`,
      '',
      true
    );
  }

  editBodega(bodegaModel: BodegaModel): Observable<BodegaModel> {
    return this.patch<BodegaModel>(
      `${this.baseEndpoint}/Update`,
      bodegaModel,
      true
    );
  }

  deleteBodega(bodegaModel: BodegaModel): Observable<BodegaModel> {
    return this.delete<BodegaModel>(
      `${this.baseEndpoint}/DeleteById`,
      bodegaModel.id_bodega,
      true
    );
  }
}
