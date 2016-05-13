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
    public class TestAccessFacade
    {
        public void CreateTestAccess(TestAccessDTO testAccess)
        {
            TestAccess newTestAccess = Mapping.Mapper.Map<TestAccess>(testAccess);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.TestAccesses.Add(newTestAccess);
                context.SaveChanges();
            }
        }

        public TestAccessDTO GetTestAccessById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var testAccess = context.TestAccesses.Find(id);
                return Mapping.Mapper.Map<TestAccessDTO>(testAccess);
            }
        }



        public void UpdateTestAccess(TestAccessDTO testAccess)
        {
            var newTestAccess = Mapping.Mapper.Map<TestAccess>(testAccess);

            using (var context = new AppDbContext())
            {
                context.Entry(newTestAccess).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTestAccess(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var testAccess = context.TestAccesses.Find(id);
                context.TestAccesses.Remove(testAccess);
                context.SaveChanges();
            };
        }



        public void DeleteTestAccess(TestAccessDTO testAccess)
        {
            var newTestAccess = Mapping.Mapper.Map<TestAccess>(testAccess);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newTestAccess).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<TestAccessDTO> GetAllTestAccesses()
        {
            using (var context = new AppDbContext())
            {
                var testAccesses = context.TestAccesses.ToList();
                return testAccesses
                    .Select(e => Mapping.Mapper.Map<TestAccessDTO>(e))
                    .ToList();
            }
        }



    }
}
