using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace DataBase
{
    public class OneGame
    {
        public int Id { get; set; }
        public List<Walk> ListMove { get; set; }
        public int[] Characters { get; set; }
    }
}
