using BL.DTO;
using BL.Facades;
using DAL;
using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentFacade = new StudentFacade();

            studentFacade.CreateStudent(new StudentDTO
            {
                FirstName = "Jon",
                Surname = "Snow",
                Email = "jsnow@gmail.com"
             });

            studentFacade.CreateStudent(new StudentDTO
            {
                FirstName = "Zuz",
                Surname = "Schwarz",
                Email = "zsch@gmail.com"
            });



        }
    }
}
