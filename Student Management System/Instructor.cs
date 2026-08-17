using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Instructor
    {
       
   
            public int Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public string Specialization { get; set; } = string.Empty;

            public ICollection<Course> Courses { get; set; } = new List<Course>();
        

    }
}
