using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("StudentExams")
        {

        }

        public DbSet<Question> Questions { set; get; }
        public DbSet<QuestionType> QuestionTypes { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudentGroup> StudentGroups { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Test> Tests { set; get; }
        public DbSet<TestAccess> TestAccesses { set; get; }
        public DbSet<ThematicArea> ThematicAreas { set; get; }

    }
}
