using Microsoft.EntityFrameworkCore;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.Models;

namespace ScrumTracker.DataObject.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<UserMasterEntity> UserMaster { get; set; } 
        public DbSet<EmpDetailsEntity> EmpDetails { get; set; }
        public DbSet<EmpScrumStatusEntity> EmpScrumStatus { get; set; }
        public DbSet<EmpWorkTypeEntity> EmpWorkType { get; set; }
        public DbSet<UserTokenEntity> UserToken { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }      
    }
}
