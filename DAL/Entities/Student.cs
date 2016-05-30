using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class Student
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string Surname { set; get; }
        [Required]
        public string Email { set; get; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
