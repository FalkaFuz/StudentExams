using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestAccessDTO
    {
         public int Id { set; get; }
        public Test Test { set; get; }
        public StudentGroup StudentGroup { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
    }
}
