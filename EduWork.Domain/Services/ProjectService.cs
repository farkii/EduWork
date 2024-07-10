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
    public class ProjectService(AppDbContext context) : IProjectService
    {
        public async Task<List<ProjectShortDto>> GetAllProjectsShortAsync()
        {
            var projects = await context.Projects.ToListAsync();
            var projectDtos = new List<ProjectShortDto>();
            projects.ForEach(project =>
            {
                projectDtos.Add(new ProjectShortDto 
                { 
                    Id = project.Id,
                    Title = project.Title
                });
            });


            return projectDtos;
        }
    }
}
