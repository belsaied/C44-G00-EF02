using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class CourseInst
    {
        public int Inst_ID { get; set; }
        public int Course_ID { get; set; }
        public string? Evaluate { get; set; }

        // Navigation Properties
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
