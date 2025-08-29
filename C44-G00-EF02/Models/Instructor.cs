using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class Instructor
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRateBouns { get; set; }
        public int Dept_ID { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
        public virtual Department? ManagedDepartment { get; set; }
        public virtual ICollection<CourseInst> CourseInstructors { get; set; } = new HashSet<CourseInst>();
    }
}
