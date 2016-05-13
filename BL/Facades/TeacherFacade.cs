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
    public class TeacherFacade
    {
        public void CreateTeacher(TeacherDTO teacher)
        {
            Teacher newTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }

        public TeacherDTO GetTeacherById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var teacher = context.Teachers.Find(id);
                return Mapping.Mapper.Map<TeacherDTO>(teacher);
            }
        }



        public void UpdateTeacher(TeacherDTO teacher)
        {
            var newTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            using (var context = new AppDbContext())
            {
                context.Entry(newTeacher).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTeacher(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var teacher = context.Teachers.Find(id);
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            };
        }



        public void DeleteTeacher(TeacherDTO teacher)
        {
            var newTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newTeacher).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<TeacherDTO> GetAllTeachers()
        {
            using (var context = new AppDbContext())
            {
                var teachers = context.Teachers.ToList();
                return teachers
                    .Select(e => Mapping.Mapper.Map<TeacherDTO>(e))
                    .ToList();
            }
        }
    }
}
