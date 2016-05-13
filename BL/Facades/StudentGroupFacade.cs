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
    public class StudentGroupFacade
    {
        public void CreateStudentGroup(StudentGroupDTO studentGroup)
        {
            StudentGroup newStudentGroup = Mapping.Mapper.Map<StudentGroup>(studentGroup);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.StudentGroups.Add(newStudentGroup);
                context.SaveChanges();
            }
        }

        public StudentGroupDTO GetStudentGroupById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var studentGroup = context.Students.Find(id);
                return Mapping.Mapper.Map<StudentGroupDTO>(studentGroup);
            }
        }



        public void UpdateStudentGroup(StudentGroupDTO studentGroup)
        {
            var newStudentGroup = Mapping.Mapper.Map<StudentGroup>(studentGroup);

            using (var context = new AppDbContext())
            {
                context.Entry(newStudentGroup).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteStudentGroup(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var studentGroup = context.StudentGroups.Find(id);
                context.StudentGroups.Remove(studentGroup);
                context.SaveChanges();
            };
        }



        public void DeleteStudentGroup(StudentGroupDTO studentGroup)
        {
            var newStudentGroup = Mapping.Mapper.Map<StudentGroup>(studentGroup);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newStudentGroup).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<StudentGroupDTO> GetAllStudentGroups()
        {
            using (var context = new AppDbContext())
            {
                var studentGroups = context.StudentGroups.ToList();
                return studentGroups
                    .Select(e => Mapping.Mapper.Map<StudentGroupDTO>(e))
                    .ToList();
            }
        }
    }
}
