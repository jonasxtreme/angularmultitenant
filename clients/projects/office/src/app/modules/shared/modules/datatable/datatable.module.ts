import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { XyzDatatableComponent } from './components/datatable/datatable.component';

import { NzTableModule } from 'ng-zorro-antd/table';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { DeepPropertyAccessPipe } from './pipes/deep-property-access.pipe';

@NgModule({
  declarations: [
    XyzDatatableComponent,
    DeepPropertyAccessPipe
  ],
  imports: [
    CommonModule,
    NzTableModule,
    NzAvatarModule
  ],
  exports: [
    XyzDatatableComponent
  ]
})
export class XyzDatatableModule { }
