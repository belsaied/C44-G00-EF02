using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Top_ID { get; set; }

        // Navigation Properties
        public Topic Topic { get; set; }
        public ICollection<StudCourse> StudCourses { get; set; } = new HashSet<StudCourse>();
        public ICollection<CourseInst> CourseInstructors { get; set; } = new HashSet<CourseInst>();
    }
}
