using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Walk
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public string Commmand { get; set; }
        public Walk(int step, string command)
        {
            this.Step = step;
            this.Commmand = command;
        }
    }
}
