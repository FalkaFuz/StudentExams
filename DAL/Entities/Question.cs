using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace StudentExams.Entities
{
    public class Question

    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        [Key]
        public int Id { set; get; }
        [Required]
        public string Text { set; get; }
        [Required]
        public int Points { set; get; }
        public string Explanation { set; get; }
        [Required]
        public virtual IList<Answer> Answers { set; get; }
        [Required]
        public virtual ThematicArea ThematicArea { set; get; }
        


    }
}
