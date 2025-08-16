using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_of_Day2
{
    public class Subject
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
