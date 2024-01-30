import { Injectable } from '@angular/core';
import { BaseAPIService } from '../shared/base-api.service';
import { HttpClient } from '@angular/common/http';
import { ClienteModel } from 'src/app/models/Clientes/cliente.model';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClientesService extends BaseAPIService {
  baseEndpoint = 'api/Cliente';
  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  createClient(clienteModel: ClienteModel): Observable<ClienteModel> {
    return this.post<ClienteModel>(
      `${this.baseEndpoint}/SignUp`,
      clienteModel,
      false
    ).pipe(map((res) => res));
  }

  listClients(): Observable<Array<ClienteModel>> {
    return this.get<Array<ClienteModel>>('api/Cliente', '', true).pipe(
      map((res) => res)
    );
  }

  updateClient(clienteModel: ClienteModel): Observable<ClienteModel> {
    return this.patch<ClienteModel>(
      `${this.baseEndpoint}/UpdateClient`,
      clienteModel,
      true
    ).pipe(map((res) => res));
  }

  deleteClient(clientId: Number): Observable<ClienteModel> {
    return this.delete<ClienteModel>(
      `${this.baseEndpoint}/DeleteClient`,
      clientId,
      true
    ).pipe(map((res) => res));
  }
}
