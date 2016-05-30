using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class ThematicArea
    {
        public ThematicArea()
        {
            Questions = new List<Question>();
        }
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public IList<Question> Questions { set; get; }

    }
}
