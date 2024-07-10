using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduWork.Data;
using EduWork.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using EduWork.Domain.Services;
using EduWork.Common.DTO;

namespace EduWork.WebAPI.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(ProjectService projectService) : ControllerBase
    {

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<List<ProjectShortDto>>> GetProjects()
        {
            return await projectService.GetAllProjectsShortAsync();
        }
    }
}
