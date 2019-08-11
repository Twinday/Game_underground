using LogicsLib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib.characters
{
    public class ElfScout:CharacterAbstract
    {
        protected int costSpecialAction { get; set; }

        public ElfScout() : base(40, 12)
        {
            this.costSpecialAction = 24;
        }

        public override void SpecialAction()
        {
            if (endurance >= costSpecialAction)
            {
                endurance -= costSpecialAction;
                endurance += plusEndurance;
                location += 3;
            }
            else
            {
                Relax();
            }
        }





    }
}
