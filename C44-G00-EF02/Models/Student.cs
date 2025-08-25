using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string? Address { get; set; }

        public int Age { get; set; }
        public int Dep_Id { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public ICollection<StudCourse> StudCourses { get; set; } = new HashSet<StudCourse>();
    }
}
