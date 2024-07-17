using Microsoft.EntityFrameworkCore;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.Models;

namespace ScrumTracker.DataObject.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<UserMasterEntity> UserMaster { get; set; } 
        public DbSet<UserTokenEntity> UserToken { get; set; }
        public DbSet<RolesEntity> Roles { get; set; } 
        public DbSet<EmpAwardEntity> EmpAward { get; set; }      
        public DbSet<EmpDetailEntity> EmpDetails { get; set; }      
    }
}
