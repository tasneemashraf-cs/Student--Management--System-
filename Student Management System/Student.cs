using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal Percentage { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public override string ToString()
        {
            return $"Id {Id}  FullName: {FullName} Emai {Email} age {Age} Percentage {Percentage} ";

        }
    }

}