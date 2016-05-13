using BL.DTO;
using DAL;
using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class TestFacade
    {
        public void CreateTest(TestDTO test)
        {
            Test newTest = Mapping.Mapper.Map<Test>(test);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tests.Add(newTest);
                context.SaveChanges();
            }
        }

        public TestDTO GetTestById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var test = context.Tests.Find(id);
                return Mapping.Mapper.Map<TestDTO>(test);
            }
        }



        public void UpdateTest(TestDTO test)
        {
            var newTest = Mapping.Mapper.Map<Test>(test);

            using (var context = new AppDbContext())
            {
                context.Entry(newTest).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTest(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var test = context.Tests.Find(id);
                context.Tests.Remove(test);
                context.SaveChanges();
            };
        }



        public void DeleteTest(TestDTO test)
        {
            var newTest = Mapping.Mapper.Map<Test>(test);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newTest).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<TestDTO> GetAllTests()
        {
            using (var context = new AppDbContext())
            {
                var tests = context.Tests.ToList();
                return tests
                    .Select(e => Mapping.Mapper.Map<TestDTO>(e))
                    .ToList();
            }
        }
    }
}
