using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using DAL.IdentityEntities;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppDbContext() : base("StudentExams")
        {

        }

        public DbSet<Question> Questions { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudentGroup> StudentGroups { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Test> Tests { set; get; }
        public DbSet<TestAccess> TestAccesses { set; get; }
        public DbSet<ThematicArea> ThematicAreas { set; get; }
        public DbSet<Answer> Answers { set; get; }

    }
    
}
