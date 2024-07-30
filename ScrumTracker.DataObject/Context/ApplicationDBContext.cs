using Microsoft.EntityFrameworkCore;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.Models;

namespace ScrumTracker.DataObject.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<UserMasterEntity> UserMaster { get; set; } 
        public DbSet<EmpDetailsEntity> EmployeeDetails { get; set; }
        public DbSet<EmpScrumStatusEntity> EmployeeScrumStatus { get; set; }
        public DbSet<EmpWorkTypeEntity> EmployeeWorkType { get; set; }
        public DbSet<UserTokenEntity> UserToken { get; set; }
        public DbSet<RolesEntity> Roles { get; set; } 
        public DbSet<EmpAwardEntity> EmployeeAward { get; set; }          
        public DbSet<QuotesEntity> Quotes { get; set; }          
        public DbSet<EmpProjectEntity> EmployeeProject { get; set; }          
    }
}
