using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class StudentDTO
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
