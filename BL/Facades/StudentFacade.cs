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
    public class StudentFacade
    {
        public void CreateStudent(StudentDTO student)
        {
            Student newStudent = Mapping.Mapper.Map<Student>(student);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Students.Add(newStudent);
                context.SaveChanges();
            }
        }

        public StudentDTO GetStudentById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var student = context.Students.Find(id);
                return Mapping.Mapper.Map<StudentDTO>(student);
            }
        }



        public void UpdateStudent(StudentDTO student)
        {
            var newStudent = Mapping.Mapper.Map<Student>(student);

            using (var context = new AppDbContext())
            {
                context.Entry(newStudent).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var student = context.Students.Find(id);
                context.Students.Remove(student);
                context.SaveChanges();
            };
        }

        

        public void DeleteStudent(StudentDTO student)
        {
            var newStudent = Mapping.Mapper.Map<Student>(student);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newStudent).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }

        public void DeleteStudentViaSql(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand("exec delete_student {0}", id);
                context.SaveChanges();
            };
        }


        public List<StudentDTO> GetAllStudents()
        {
            using (var context = new AppDbContext())
            {
                var students = context.Students.ToList();
                return students
                    .Select(e => Mapping.Mapper.Map<StudentDTO>(e))
                    .ToList();
            }
        }

            public StudentDTO GetSpecificStudent()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var student = context.Students
                              .SqlQuery("SELECT * FROM dbo.Students WHERE Id = '1'");
                return Mapping.Mapper.Map<StudentDTO>(student.Single());
            }
        }
    
    }
}
