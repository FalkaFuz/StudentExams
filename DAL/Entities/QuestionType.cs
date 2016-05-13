using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class QuestionType
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public int Value { set; get; }
    }
}
