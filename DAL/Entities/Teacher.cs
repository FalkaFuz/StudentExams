using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string Surname { set; get; }
    }
}
