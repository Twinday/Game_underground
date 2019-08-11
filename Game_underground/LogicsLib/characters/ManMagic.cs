using LogicsLib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib.characters
{
    public class ManMagic:CharacterAbstract
    {
        //public event Action<object, object> SpecAct;
        protected int costSpecialAction { get; set; }

        public ManMagic():base(30, 13)
        {
            this.costSpecialAction = 15;
        }

        public override void SpecialAction()
        {
            if (endurance >= costSpecialAction)
            {
                endurance -= costSpecialAction;
                endurance += plusEndurance;
                location++;
            }
            else
                Relax();
            // надо дописать
        }



    }
}
