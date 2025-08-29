using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
