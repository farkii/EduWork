using EduWork.Common.DTO;
using EduWork.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace EduWork.WebAPI.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController(UserProfileService userProfileService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<AppRoleDto>> GetUserProfiles(int id)
        {
            return await userProfileService.GetUserAppRoleAsync(id);
        }
    }
}
