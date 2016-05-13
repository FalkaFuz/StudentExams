using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Time { set; get; }
        public int QuestionCount { set; get; }
        public ThematicArea ThematicArea { set; get; }
    }
}
