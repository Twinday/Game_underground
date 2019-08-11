using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase
{
    public class GameContext:DbContext
    {
        //public GameContext(): base("DbGame"){ }
        public DbSet<OneGame> Games { get; set; }
    }
}
