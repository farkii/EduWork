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
using EduWork.Common.DTO;

namespace EduWork.WebAPI.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController(UserProfileService userProfileService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles() { 
            return await userProfileService.GetAllUserProfilesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
            var user = await userProfileService.GetUserProfileAsync(id);

            if (user == null) { 
                return NotFound();
            }
            return user;
        }

        [HttpGet("projects/{id}")]
        public async Task<ActionResult<IEnumerable<UserProject>>> GetUserProjects(int id)
        {
            return await userProfileService.GetAllUserProjectsAsync(id);
        }

        [HttpGet("annualleave/{id}")]
        public async Task<ActionResult<IEnumerable<AnnualLeaveDTO>>> GetUserAnnualLeaves(int id)
        {
            return await userProfileService.GetUserAnnualLeaveAsync(id);
        }

        [HttpGet("annualleaverecords/{id}")]
        public async Task<ActionResult<IEnumerable<AnnualLeaveRecordDTO>>> GetUserAnnualLeaveRecords(int id)
        {
            return await userProfileService.GetUserAnnualLeaveRecordsAsync(id);
        }

        [HttpGet("sickleaverecords/{id}")]
        public async Task<ActionResult<IEnumerable<SickLeaveRecordDTO>>> GetUserSickLeaveRecords(int id)
        {
            return await userProfileService.GetUserSickLeaveRecordsAsync(id);
        }

    }
}
