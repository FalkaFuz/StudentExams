using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Answer
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Text { set; get; }
        [Required]
        public Boolean IsCorrect { set; get; }
        [Required]
        public virtual Question Question { set; get; }

    }
}
