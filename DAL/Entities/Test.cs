using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExams.Entities
{
    public class Test
    {
        public Test()
        {
            TestAccesses = new List<TestAccess>();
        }
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Time { set; get; }
        [Required]
        public int QuestionCount { set; get; }
        [Required]
        public ThematicArea ThematicArea { set; get; }
        public IList<TestAccess> TestAccesses { set; get; }


    }
}
