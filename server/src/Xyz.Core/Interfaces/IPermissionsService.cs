using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permission>> FindAll();
        Task<IEnumerable<ModulePermission>> FindAllModulePermissions();
        Task<Page<TemplateModulePermissionNameDto>> SearchTemplateModulePermissionNames(PageRequest pageRequest, BasicQuerySearchFilter filter);
        Task<TemplateModulePermissionNameDto> SaveTemplateModulePermissionName(TemplateModulePermissionName template);
        Task<TemplateModulePermissionNameDto> FindTemplateModulePermissionNameById(string templateModulePermissionNameId);
        Task<TemplateModulePermissionNameDto> DeleteTemplateModulerPermissionNameById(string templateModulePermissionNameId);
        Task<TemplateModulePermissionNameDto> UpdateTemplateModulePermissionName(string templateModulePermissionNameId, TemplateModulePermissionName template);
    }
}
