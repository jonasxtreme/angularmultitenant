using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Models;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Entities.Multitenancy;

using Xyz.Multitenancy.Security;
using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private ILogger<TenantsController> _logger;
        private ITenantsService _tenantsService;
        private ITenantAccessor<Tenant> _tenantAccessor;

        public TenantsController(
            ILogger<TenantsController> logger,
            ITenantsService tenantsService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._tenantsService = tenantsService;
            this._tenantAccessor = tenantAccessor;
        }

        [HttpGet("statistics")]
        [Authorize(Policy = PolicyNames.RequireTenant)]
        public async Task<ActionResult<TenantStatistics>> GetTenantStatistics()
        {
            try
            {
                var tenantId = this._tenantAccessor.Tenant.Id.ToString() ?? "";
                return Ok(await this._tenantsService.GetTenantStatisticsAsync(tenantId));
            }
            catch (Exception ex)
            {
                this._logger.LogError($"There was an error getting tenant statistics!");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpGet("from-subdomain")]
        public async Task<ActionResult<TenantDto>> FindTenantFromSubdomain([FromQuery] string subdomain)
        {
            try
            {
                return Ok(await this._tenantsService.FindTenantFromSubdomainAsync(subdomain));
            }
            catch (Exception ex)
            {
                this._logger.LogError($"There was an error, {ex.Message}");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = ex.Message
                    }
                );
            }
        }
    }
}