using Xunit;
using Microsoft.EntityFrameworkCore;
using EduWork.Domain.Services;
using EduWork.Data;
using EduWork.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduWork.Common.DTO;
using System.Linq;
using System;

namespace EduWork.Tests
{
    public class UserProfileServiceTests
    {
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;
        private UserProfileService _service;

        public UserProfileServiceTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "UserProfileServiceTests")
                .Options;

            _context = new AppDbContext(_options);
            _service = new UserProfileService(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var appRoles = new List<AppRole>
            {
                new AppRole { Id = 1, Title = "Admin", Description = "Administrator" },
                new AppRole { Id = 2, Title = "User", Description = "Standard User" }
            };

            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Email = "user1@example.com", AppRoleId = 1, EntraObjectId = "mockId1" },
                new User { Id = 2, Username = "user2", Email = "user2@example.com", AppRoleId = 2, EntraObjectId = "mockId2" }
            };

            var projects = new List<Project>
            {
                new Project { Id = 1, Title = "Project1", StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-2)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(2)), Description = "Project 1 description", isFinished = false, isPrivate = true, isEducation = true, isPayable = false, DevopsProjectId = "devopsId1" },
                new Project { Id = 2, Title = "Project2", StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3)), Description = "Project 2 description", isFinished = false, isPrivate = true, isEducation = true, isPayable = false, DevopsProjectId = "devopsId2" }
            };

            var projectRoles = new List<ProjectRole>
            {
                new ProjectRole { Id = 1, Title = "Developer", Description = "Description1" },
                new ProjectRole { Id = 2, Title = "Manager", Description = "Descritpion2" }
            };

            var userProjectRoles = new List<UserProjectRole>
            {
                new UserProjectRole { UserId = 1, ProjectId = 1, ProjectRoleId = 1 },
                new UserProjectRole { UserId = 2, ProjectId = 2, ProjectRoleId = 2 }
            };

            var annualLeaves = new List<AnnualLeave>
            {
                new AnnualLeave { Id = 1, UserId = 1, Year = DateTime.Now.Year, TotalLeaveDays = 20, LeaveDaysLeft = 15 },
                new AnnualLeave { Id = 2, UserId = 2, Year = DateTime.Now.Year, TotalLeaveDays = 25, LeaveDaysLeft = 20 }
            };

            var annualLeaveRecords = new List<AnnualLeaveRecord>
            {
                new AnnualLeaveRecord { Id = 1, UserId = 1, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), Comment = "Vacation" },
                new AnnualLeaveRecord { Id = 2, UserId = 2, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-20)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-15)), Comment = "Holiday" }
            };

            var sickLeaveRecords = new List<SickLeaveRecord>
            {
                new SickLeaveRecord { Id = 1, UserId = 1, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), EndDate = DateOnly.FromDateTime(DateTime.Now), Comment = "Flu" },
                new SickLeaveRecord { Id = 2, UserId = 2, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), Comment = "Cold" }
            };

            _context.AppRoles.AddRange(appRoles);
            _context.Users.AddRange(users);
            _context.Projects.AddRange(projects);
            _context.ProjectRoles.AddRange(projectRoles);
            _context.UserProjectRoles.AddRange(userProjectRoles);
            _context.AnnualLeaves.AddRange(annualLeaves);
            _context.AnnualLeaveRecords.AddRange(annualLeaveRecords);
            _context.SickLeaveRecords.AddRange(sickLeaveRecords);

            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllUserProfilesAsync_ShouldReturnAllProfiles()
        {
            var result = await _service.GetAllUserProfilesAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUserProfileAsync_ShouldReturnProfileDetails()
        {
            var result = await _service.GetUserProfileAsync(1);

            Assert.NotNull(result);
            Assert.Equal("user1", result.Username);
            Assert.Equal("user1@example.com", result.Email);
        }

        [Fact]
        public async Task GetUserByUsernameAsync_ShouldReturnProfileDetails()
        {
            var result = await _service.GetUserByUsernameAsync("user1");
            
            Assert.NotNull(result);
            Assert.Equal("user1", result.Username);
            Assert.Equal("user1@example.com", result.Email);
        }

        [Fact]
        public async Task GetUserAppRoleAsync_ShouldReturnAppRole()
        {
            var result = await _service.GetUserAppRoleAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Admin", result.Title);
            Assert.Equal("Administrator", result.Description);
        }

        [Fact]
        public async Task GetAllUserProjectsAsync_ShouldReturnUserProjects()
        {
            var result = await _service.GetAllUserProjectsAsync(1);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Project1", result.First().Title);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddMonths(-2)), result.First().StartDate);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddMonths(2)), result.First().EndDate);
        }

        [Fact]
        public async Task GetUserAnnualLeaveAsync_ShouldReturnUserAnnualLeaves()
        {
            var result = await _service.GetUserAnnualLeaveAsync(1);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(20, result.First().TotalLeaveDays);
            Assert.Equal(15, result.First().LeaveDaysLeft);
        }

        [Fact]
        public async Task GetUserAnnualLeaveRecordsAsync_ShouldReturnUserAnnualLeaveRecords()
        {
            var result = await _service.GetUserAnnualLeaveRecordsAsync(1);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Vacation", result.First().Comment);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), result.First().StartDate);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), result.First().EndDate);
        }

        [Fact]
        public async Task GetUserSickLeaveRecordsAsync_ShouldReturnUserSickLeaveRecords()
        {
            var result = await _service.GetUserSickLeaveRecordsAsync(1);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Flu", result.First().Comment);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), result.First().StartDate);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now), result.First().EndDate);
        }

        [Fact]
        public async Task ToProfileShortDto_ShouldReturnProfileShortDto()
        {
            var user = new User { Id = 1, Username = "user1", Email = "user1@example.com" };

            var result = await _service.ToProfileShortDto(user);

            Assert.NotNull(result);
            Assert.Equal("user1", result.Username);
            Assert.Equal("user1@example.com", result.Email);
            Assert.Single(result.Projects);
            Assert.Equal("Project1", result.Projects.First().Title);
        }
    }
}