using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementSystem.Models
{
    public class DB:DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<UserProfile> Profiles { get; set; }
    }
}