using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using EduWork.Domain.Contracts;
using EduWork.Domain.Services;
using EduWork.Common.DTO.User;

namespace EduWork.WebAPI.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController(IUserProfileService userProfileService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileShortDto>>> GetUserProfiles() { 
            return await userProfileService.GetAllUserProfilesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDetailsDto>> GetUserProfile(int id)
        {
            var user = await userProfileService.GetUserProfileAsync(id);

            if (user == null) { 
                return NotFound();
            }
            return user;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<ProfileDetailsDto>> GetUserByUsername(string username)
        {
            var user = await userProfileService.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
