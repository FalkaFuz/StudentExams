using DAL.Entities;
using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
   public class QuestionDTO
    {
        public int Id { set; get; }
        public string Text { set; get; }
         public int Points { set; get; }
        public string Explanation { set; get; }
        public IList<AnswerDTO> Answers { set; get; }
        public ThematicAreaDTO ThematicArea { set; get; }
    }
}
