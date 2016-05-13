using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class TestAccess
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public Test Test { set; get; }
        [Required]
        public StudentGroup StudentGroup { set; get; }
        [Required]
        public DateTime StartTime { set; get; }
        [Required]
        public DateTime EndTime { set; get; }
    }
}
