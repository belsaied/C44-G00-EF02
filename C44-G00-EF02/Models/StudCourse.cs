using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class StudCourse
    {
        public int Stud_ID { get; set; }
        public int Course_ID { get; set; }
        public string? Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; } 
        public Course Course { get; set; }
    }
}
