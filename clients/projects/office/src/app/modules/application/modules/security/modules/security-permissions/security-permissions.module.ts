import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecurityPermissionsComponent } from './pages/security-permissions/security-permissions.component';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzPopoverModule } from 'ng-zorro-antd/popover';

import { SecurityPermissionsRoutingModule } from './security-permissions-routing.module';
import { SecurityPermissionsCreateComponent } from './pages/security-permissions-create/security-permissions-create.component';
import { SecurityPermissionsUpdateComponent } from './pages/security-permissions-update/security-permissions-update.component';

import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';
import { XyzQuerySearchFilterModule } from '@xyz/office/modules/shared/modules/query-search-filter';

@NgModule({
  declarations: [
    SecurityPermissionsComponent,
    SecurityPermissionsCreateComponent,
    SecurityPermissionsUpdateComponent
  ],
  imports: [
    CommonModule,
    SecurityPermissionsRoutingModule,
    XyzDatatableModule,
    XyzQuerySearchFilterModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule,
    NzPopoverModule
  ]
})
export class SecurityPermissionsModule { }
