import { Injectable } from '@angular/core';
import { BaseAPIService } from './base-api.service';
import { AuthenticationModel } from 'src/app/models/Authentication/authentication.model';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { AuthResponseModel } from 'src/app/models/Authentication/authResponse.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService extends BaseAPIService {
  constructor(private _httpClientResolve: HttpClient) {
    super(_httpClientResolve);
  }

  public loginToAPI(
    authenticationModel: AuthenticationModel
  ): Observable<String> {
    return this.post<AuthResponseModel>(
      'api/Cliente/SignIn',
      authenticationModel,
      false
    ).pipe(map((res) => res.jwt));
  }
}
