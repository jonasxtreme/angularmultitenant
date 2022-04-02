import { Pipe, PipeTransform } from '@angular/core';

import { PermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanDelete'
})
export class XyzCanDeletePipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: PermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canDelete || false
      : false;
  }
}
