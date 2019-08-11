using LogicsLib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib.characters
{
    public class DwarfWarrior : CharacterAbstract
    {
        protected int costSpecialAction { get; set; }

        public DwarfWarrior() : base(50, 15)
        {
            this.costSpecialAction = 20;
        }

        public override void SpecialAction()
        {
            if (endurance >= costSpecialAction)
            {
                endurance -= costSpecialAction;
                endurance += plusEndurance;
                location++;
            }
            // надо дописать
        }

        /*public int Deadline()
        {
            return Location;
        }*/



    }
}
