using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Ins_ID { get; set; }
        public DateTime HiringDate { get; set; }
    }
}
