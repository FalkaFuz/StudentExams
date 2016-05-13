using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StudentExams.Entities
{
    public class Question
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Text { set; get; }
        [Required]
        public int Points { set; get; }
        public string Explanation { set; get; }
        [Required]
        public QuestionType QuestionType { set; get; }
        [Required]
        public ThematicArea ThematicArea { set; get; }


    }
}
