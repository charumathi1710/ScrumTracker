﻿using Microsoft.EntityFrameworkCore;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.Models;

namespace ScrumTracker.DataObject.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        public DbSet<UserMasterEntity> UserMaster { get; set; } 
        public DbSet<UserStatusEntity> UserStatus { get; set; }
 
       
    }
}
