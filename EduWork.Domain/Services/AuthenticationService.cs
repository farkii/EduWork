using EduWork.Data;
using EduWork.Data.Entities;
using EduWork.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using EduWork.Common.DTO.User;


namespace EduWork.Domain.Services
{
    public class AuthenticationService(AppDbContext context) : IAuthenticationService
    {
        public async Task<LoggedInUserDto> UserAuthenticationAsync(string email, string name, string objectId)
        {
            var user = await context.Users.Where(u => u.Email == email).Select(u => u).FirstOrDefaultAsync();
            if (user == null)
            {
                context.Users.Add(new User
                {
                    Username = name,
                    Email = email,
                    AppRoleId = 2,
                    EntraObjectId = objectId
                });
                context.SaveChanges();
            }


            user = await context.Users.Where(u => u.Email == email).Select(u => u).FirstOrDefaultAsync(); 
            var appRole = await context.AppRoles.Where(ar => ar.Id == user.AppRoleId).Select(ar => ar.Title).FirstOrDefaultAsync();

            LoggedInUserDto loggedInUser = new LoggedInUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                EntraObjectId = user.EntraObjectId,
                AppRole = appRole
            };

            return loggedInUser;
        }
    }
}
