import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BaseAPIService {
  public headers: HttpHeaders;
  public API_ROOT = 'https://localhost:7027/';

  constructor(protected _httpClient: HttpClient) {
    this.headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
    });
    /* IMPORTANT: For requests without credentials, the literal value "*" can be specified as a wildcard;
    the value tells browsers to allow requesting code from any origin to access the resource.
    Attempting to use the wildcard with credentials results in an error.
    https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Access-Control-Allow-Origin */
  }

  /*********************/
  /*JWT Methods */
  /*********************/

  private getTokenFromCookie() {
    return localStorage.getItem('token');
  }

  public addAutorization() {
    this.headers = new HttpHeaders({
      Authorization: `Bearer ${this.getTokenFromCookie()}`,
    });
  }

  /*********************/
  /*CRUD Methods*/
  /*********************/
  /**
   *
   *
   * @template Tmodel - Model corresponding to the table of the endpoint
   * @param {string} endPoint - API endpoint string
   * @param {string} queryString - Query parameters
   * @param {boolean} [authorization] - Wheter to use JWT auth or not
   * @return {*}  {Observable<Tmodel>} - Observable to handle response data
   * @memberof BaseAPIService
   */
  public get<Tmodel>(
    endPoint: string,
    queryString: string,
    authorization?: boolean
  ): Observable<Tmodel> {
    if (authorization) {
      this.addAutorization();
    }
    return this._httpClient.get<Tmodel>(
      `${this.API_ROOT}${endPoint}${queryString}`,
      {
        headers: this.headers,
      }
    );
  }
  /**
   *
   *
   * @template Tmodel - Model corresponding to the table of the endpoint
   * @param {string} endPoint - API endpoint string
   * @param {*} object - Object to save to the database, usually a model of a table
   * @param {boolean} [addAutorization] - Wheter to use JWT auth or not
   * @return {*}  {Observable<Tmodel>} - Observable to handle response data
   * @memberof BaseAPIService
   */
  public post<Tmodel>(
    endPoint: string,
    object: any,
    addAutorization?: boolean
  ): Observable<Tmodel> {
    if (addAutorization) {
      this.addAutorization();
    }
    return this._httpClient.post<Tmodel>(
      `${this.API_ROOT}${endPoint}`,
      object,
      {
        headers: this.headers,
      }
    );
  }
  /**
   *
   *
   * @template Tmodel - Model corresponding to the table of the endpoint
   * @param {string} endPoint - API endpoint string
   * @param {*} object - Object to patch, usually a model of a table
   * @param {boolean} [addAutorization] - Wheter to use JWT auth or not
   * @return {*}  {Observable<Tmodel>} - Observable to handle response data
   * @memberof BaseAPIService
   */
  public patch<Tmodel>(
    endPoint: string,
    object: any,
    addAutorization?: boolean
  ): Observable<Tmodel> {
    if (addAutorization) {
      this.addAutorization();
    }
    return this._httpClient.patch<Tmodel>(
      `${this.API_ROOT}${endPoint}`,
      object,
      {
        headers: this.headers,
      }
    );
  }
  /**
   *
   *
   * @template Tmodel - Model corresponding to the table of the endpoint
   * @param {string} endPoint - API endpoint string
   * @param {number} id - Id of tyhe object to delete
   * @param {boolean} [addAutorization] - Wheter to use JWT auth or not
   * @return {*}  {Observable<Tmodel>} - Observable to handle response data
   * @memberof BaseAPIService
   */
  public delete<Tmodel>(
    endPoint: string,
    id: Number,
    addAuthorization?: boolean
  ): Observable<Tmodel> {
    if (addAuthorization) {
      this.addAutorization();
    }
    return this._httpClient.delete<Tmodel>(
      `${this.API_ROOT}${endPoint}?id=${id}`,
      {
        headers: this.headers,
      }
    );
  }
  /**
   * Method created to delete items from a table that ahs a composite key
   *
   * @template Tmodel - Model corresponding to the table of the endpoint
   * @param {string} endPoint - API endpoint string
   * @param {Number} idProd - ID of the related product
   * @param {Number} idBod - ID of the related wharehouse
   * @param {boolean} [addAutorization] - Wheter to use JWT auth or not
   * @return {*}  {Observable<Tmodel>} - Observable to handle response data
   * @memberof BaseAPIService
   */
  public deleteDisp<Tmodel>(
    endPoint: string,
    idProd: Number,
    idBod: Number,
    addAuthorization?: boolean
  ): Observable<Tmodel> {
    if (addAuthorization) {
      this.addAutorization();
    }
    return this._httpClient.delete<Tmodel>(
      `${this.API_ROOT}${endPoint}?idProducto=${idProd}&idBodega=${idBod}`,
      {
        headers: this.headers,
      }
    );
  }
}
