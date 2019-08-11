using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib
{
    public class Status
    {
        public int Endurance { get; set; }
        public int Location { get; set; }
        public Status(int endurance, int location)
        {
            this.Endurance = endurance;
            this.Location = location;
        }
        public Status()
        {
            
        }
    }
}
