import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, Observable, of, switchMap } from 'rxjs';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';
import { PermissionNames, UserModulesAndPermissionsMap } from '../../models';


@Injectable({
  providedIn: 'root'
})
export class CanReadPermissionGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _store: Store<fromRoot.RootState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const permissionName: PermissionNames = route.data['requiredPermissionName'] as PermissionNames;
    
    return this._store.select(fromUser.selectUserModulePermissionsMap)
      .pipe(
        switchMap((permissions: UserModulesAndPermissionsMap | null) => {
          const hasReadPermission: boolean = permissions ? (permissions?.permissions[permissionName]?.canRead || false) : false;

          if (!hasReadPermission) {
            this._router.navigateByUrl('/error/403');
          }

          return of(hasReadPermission);
        }),
        catchError(() => {
          this._router.navigateByUrl('/error/403');
          return of(false);
        })
      );
  }
}
