using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class StudentGroup
    {
        public StudentGroup()
        {
            Students = new List<Student>();
        }
        [Key]
        public int Id { set; get; }
        public IList<Student> Students { set; get; }
        [Required]
        public string RegistrationCode { set; get; }
    }
}
