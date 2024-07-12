using EduWork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<AnnualLeave> AnnualLeaves { get; set; }

        public DbSet<AnnualLeaveRecord> AnnualLeaveRecords { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<NonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ProjectTime> ProjectTimes { get; set; }
        public DbSet<SickLeaveRecord> SickLeaveRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProjectRole> UserProjectRoles { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<WorkDayTime> WorkDayTimes { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer("Server=.;Database=EduWorkDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }


}
}
