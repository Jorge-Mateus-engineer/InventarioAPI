import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { DisponibilidadModel } from 'src/app/models/Disponibilidad/disponibilidad.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DisponibilidadService extends BaseAPIService {
  baseEndpoint = 'api/Disponibilidad';

  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createDisponibilidad(
    disponibilidadModel: DisponibilidadModel
  ): Observable<DisponibilidadModel> {
    return this.patch<DisponibilidadModel>(
      `${this.baseEndpoint}/Create`,
      disponibilidadModel,
      true
    );
  }
}
