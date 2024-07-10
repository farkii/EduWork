using EduWork.Common.DTO;
using EduWork.Data;
using EduWork.Data.Entities;
using EduWork.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Domain.Services
{
    public class UserProfileService(AppDbContext context) : IUserProfileService
    {
        public async Task<List<ProfileShortDto>> GetAllUserProfilesAsync(){
            var users = await context.Users.ToListAsync();
            var userProfiles = new List<ProfileShortDto>();
            foreach (var user in users)
            {
                var userProfile = await ToProfileShortDto(user);
                userProfiles.Add(userProfile);
            }

            return userProfiles;
        }

        public async Task<ProfileDetailsDto> GetUserProfileAsync(int userId)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            var projects = await GetAllUserProjectsAsync(userId);
            var annualLeaves = await GetUserAnnualLeaveAsync(userId);
            var annualLeave = from al in annualLeaves where al.Year == DateTime.Now.Year select al;
            var annualLeaveRecords = await GetUserAnnualLeaveRecordsAsync(userId);
            var sickLeaveRecords = await GetUserSickLeaveRecordsAsync(userId);

            var userProfile = new ProfileDetailsDto()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Projects = projects,
                AnnualLeave = annualLeave.FirstOrDefault(),
                AnnualLeaveRecords = annualLeaveRecords,
                SickLeaveRecords = sickLeaveRecords
            };


            return userProfile;
        }

        public async Task<ProfileDetailsDto> GetUserByUsernameAsync(string username)
        {
            var user = await context.Users.Where(u => u.Username == username).Select(u => u).FirstOrDefaultAsync();
            if (user == null) 
            {
                return null;    
            }

            var projects = await GetAllUserProjectsAsync(user.Id);
            var annualLeaves = await GetUserAnnualLeaveAsync(user.Id);
            var annualLeave = from al in annualLeaves where al.Year == DateTime.Now.Year select al;
            var annualLeaveRecords = await GetUserAnnualLeaveRecordsAsync(user.Id);
            var sickLeaveRecords = await GetUserSickLeaveRecordsAsync(user.Id);

            var userProfile = new ProfileDetailsDto()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Projects = projects,
                AnnualLeave = annualLeave.FirstOrDefault(),
                AnnualLeaveRecords = annualLeaveRecords,
                SickLeaveRecords = sickLeaveRecords
            };


            return userProfile;
        }

        public async Task<AppRoleDto> GetUserAppRoleAsync(int userId)
        {
            var user = await context.Users.FindAsync(userId);
            var appRole = await context.AppRoles.Where(ar => ar.Id == user.AppRoleId).FirstOrDefaultAsync();
            var profileShort = await ToProfileShortDto(user);

            var userAppRole = new AppRoleDto()
            {
                Id = appRole.Id,
                Title = appRole.Title,
                Description = appRole.Description,
                ProfileShort = profileShort

            };


            return userAppRole;
        }

        public async Task<List<UserProjectDto>> GetAllUserProjectsAsync(int userId)
        {
            var projects = await context.UserProjectRoles.Where(upr => upr.UserId == userId).Select(upr => upr.Project).ToListAsync();

            var userProjects = new List<UserProjectDto>();
            foreach (var project in projects)
            {
                var roleName = context.UserProjectRoles.Where(upr => upr.ProjectId == project.Id).Select(upr => upr.ProjectRole.Title).FirstOrDefault(); 

                userProjects.Add(new UserProjectDto()
                {
                    Id = project.Id,
                    Title = project.Title,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Description = project.Description,
                    RoleName = roleName
                });
            }
            return userProjects;
        }

        public async Task<List<AnnualLeaveDto>> GetUserAnnualLeaveAsync(int userId)
        {
            var annualLeaves = await context.AnnualLeaves.Where(al => al.UserId == userId).ToListAsync();
            var userAnnualLeaves = new List<AnnualLeaveDto>();
            annualLeaves.ForEach(annualLeave =>
            {
                userAnnualLeaves.Add(new AnnualLeaveDto()
                {
                    Id = annualLeave.Id,
                    Year = annualLeave.Year,
                    TotalLeaveDays = annualLeave.TotalLeaveDays,
                    LeaveDaysLeft = annualLeave.LeaveDaysLeft
                });
            });


            return userAnnualLeaves;
        }

        public async Task<List<AnnualLeaveRecordDto>> GetUserAnnualLeaveRecordsAsync(int userId)
        {
            var annualLeaveRecords = await context.AnnualLeaveRecords.Where(alr => alr.UserId == userId).ToListAsync();
            var userAnnualLeaveRecords = new List<AnnualLeaveRecordDto>();
            annualLeaveRecords.ForEach(annualLeaveRecord =>
            {
                userAnnualLeaveRecords.Add(new AnnualLeaveRecordDto()
                {
                    Id = annualLeaveRecord.Id,
                    StartDate = annualLeaveRecord.StartDate,
                    EndDate = annualLeaveRecord.EndDate,
                    Comment = annualLeaveRecord.Comment
                });
            });


            return userAnnualLeaveRecords;
        }

        public async Task<List<SickLeaveRecordDto>> GetUserSickLeaveRecordsAsync(int userId)
        {
            var sickLeaveRecords = await context.SickLeaveRecords.Where(alr => alr.UserId == userId).ToListAsync();
            var userSickLeaveRecords = new List<SickLeaveRecordDto>();
            sickLeaveRecords.ForEach(sickLeaveRecord =>
            {
                userSickLeaveRecords.Add(new SickLeaveRecordDto()
                {
                    Id = sickLeaveRecord.Id,
                    StartDate = sickLeaveRecord.StartDate,
                    EndDate = sickLeaveRecord.EndDate,
                    Comment = sickLeaveRecord.Comment
                });
            });


            return userSickLeaveRecords;
        }

        private async Task<ProfileShortDto> ToProfileShortDto(User user)
        {
            var projects = await GetAllUserProjectsAsync(user.Id);
            var profileShort = new ProfileShortDto()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Projects = projects
            };

            return profileShort;
        }
    }
}
