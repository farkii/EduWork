using EduWork.Common.DTO;
using EduWork.Data;
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
        public async Task<List<UserProfile>> GetAllUserProfilesAsync(){
            var users = await context.Users.ToListAsync();
            var userProfiles = new List<UserProfile>();
            users.ForEach(user =>
            {
                userProfiles.Add(new UserProfile() { 
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email
                });
            });


            return userProfiles;
        }

        public async Task<UserProfile> GetUserProfileAsync(int userId)
        {
            var user = await context.Users.FindAsync(userId);

            var userProfile = new UserProfile()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };


            return userProfile;
        }

        public async Task<List<UserProject>> GetAllUserProjectsAsync(int userId)
        {
            var projects = await context.UserProjectRoles.Where(upr => upr.UserId == userId).Select(upr => upr.Project).ToListAsync();

            var userProjects = new List<UserProject>();
            foreach (var project in projects)
            {
                var roleName = context.UserProjectRoles.Where(upr => upr.ProjectId == project.Id).Select(upr => upr.ProjectRole.Title).FirstOrDefault(); 

                userProjects.Add(new UserProject()
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

        public async Task<List<AnnualLeaveDTO>> GetUserAnnualLeaveAsync(int userId)
        {
            var annualLeaves = await context.AnnualLeaves.Where(al => al.UserId == userId).ToListAsync();
            var userAnnualLeaves = new List<AnnualLeaveDTO>();
            annualLeaves.ForEach(annualLeave =>
            {
                userAnnualLeaves.Add(new AnnualLeaveDTO()
                {
                    Id = annualLeave.Id,
                    Year = annualLeave.Year,
                    TotalLeaveDays = annualLeave.TotalLeaveDays,
                    LeaveDaysLeft = annualLeave.LeaveDaysLeft
                });
            });


            return userAnnualLeaves;
        }

        public async Task<List<AnnualLeaveRecordDTO>> GetUserAnnualLeaveRecordsAsync(int userId)
        {
            var annualLeaveRecords = await context.AnnualLeaveRecords.Where(alr => alr.UserId == userId).ToListAsync();
            var userAnnualLeaveRecords = new List<AnnualLeaveRecordDTO>();
            annualLeaveRecords.ForEach(annualLeaveRecord =>
            {
                userAnnualLeaveRecords.Add(new AnnualLeaveRecordDTO()
                {
                    Id = annualLeaveRecord.Id,
                    StartDate = annualLeaveRecord.StartDate,
                    EndDate = annualLeaveRecord.EndDate,
                    Comment = annualLeaveRecord.Comment
                });
            });


            return userAnnualLeaveRecords;
        }

        public async Task<List<SickLeaveRecordDTO>> GetUserSickLeaveRecordsAsync(int userId)
        {
            var sickLeaveRecords = await context.SickLeaveRecords.Where(alr => alr.UserId == userId).ToListAsync();
            var userSickLeaveRecords = new List<SickLeaveRecordDTO>();
            sickLeaveRecords.ForEach(sickLeaveRecord =>
            {
                userSickLeaveRecords.Add(new SickLeaveRecordDTO()
                {
                    Id = sickLeaveRecord.Id,
                    StartDate = sickLeaveRecord.StartDate,
                    EndDate = sickLeaveRecord.EndDate,
                    Comment = sickLeaveRecord.Comment
                });
            });


            return userSickLeaveRecords;
        }
    }
}
