import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { AuthenticationService } from '../services/shared/authentication.service';
import { inject } from '@angular/core';
import { map, Observable, of } from 'rxjs';

export const adminGuard: CanActivateFn = (
  route,
  state
): Observable<boolean | UrlTree> => {
  const _authService = inject(AuthenticationService);

  const router = new Router();

  const currentToken = localStorage.getItem('token');

  if (currentToken) {
    return _authService.verifyToken(currentToken).pipe(
      map((res) => {
        if (res.tokenValidity === 'Valid Token') {
          return true;
        } else {
          return router.createUrlTree(['/auth']);
        }
      })
    );
  } else {
    return of(router.createUrlTree(['/auth']));
  }
};
