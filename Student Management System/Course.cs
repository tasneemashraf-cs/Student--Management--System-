using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string	Description { get; set; }

        public int  DurationInHours { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
