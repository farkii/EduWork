using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System.Security.Claims;
using EduWork.WebAPI.Controllers;
using Microsoft.Identity.Web.Resource;
using EduWork.Domain.Services;
using EduWork.Common.DTO.User;
using EduWork.Domain.Contracts;
using EduWork.WebAPI.Authentication;

[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthenticationController(IAuthenticationService service, EduWork.WebAPI.Authentication.Identity identity) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LoggedInUserDto>> PostAuthentication()
    {
        try
        {
            if(identity.Email == null || identity.DisplayName == null || identity.ObjectId == null)
            {
                return BadRequest("Progreška tijekom autentikacije");
            }
            var loggedInUser = await service.UserAuthenticationAsync(identity.Email, identity.DisplayName, identity.ObjectId.ToString());

            if (loggedInUser == null)
            {
                return NotFound();
            }

            return loggedInUser;
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine("Error processing PostUser request: " + ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }


}
