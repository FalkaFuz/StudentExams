using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class StudentGroupDTO
    {
        public int Id { set; get; }
        public IList<Student> Students { set; get; }
        public string RegistrationCode { set; get; }
    }
}
