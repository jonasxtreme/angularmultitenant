import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { TenantStatistics } from '../../models';
import { EnvironmentService } from '../environment.service';

@Injectable({
  providedIn: 'root'
})
export class TenantsService {
  private readonly _endpointSlug: string = 'tenants';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public findTenantBySubdomain(subdomain: string): Observable<Tenant> {
    const queryParms: {[key: string]: string} = { subdomain };
    return this._http.get<Tenant>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/from-subdomain`,
      { params: queryParms }
    );
  }

  public getTenantStatistics(): Observable<TenantStatistics> {
    return this._http.get<TenantStatistics>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/statistics`
    );
  }
}