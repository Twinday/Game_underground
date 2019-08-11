using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib.interfaces
{
    public abstract class CharacterAbstract:ICharacter
    {
        private int MaxEndurance { get; set; }

        protected int endurance { get; set; }
        public int Endurance { get { return endurance; } }

        private int costDescent { get; set; }

        private int costFastDescent { get; set; }

        internal int location { get; set; }
        public int Location { get { return location; } }

        public int plusEndurance { get; set; }

        public CharacterAbstract(int endurance, int costfastdescent)
        {
            this.MaxEndurance = endurance;
            this.endurance = endurance;
            this.costDescent = 5;
            this.costFastDescent = costfastdescent;
            this.location = 0;
            this.plusEndurance = 2;
        }

        public void Descent()
        {
            if (endurance >= costDescent)
            {
                location++;
                endurance -= costDescent;
                endurance += plusEndurance;
            }
            else
                Relax();
        }

        public void FastDescent()
        {
            if (endurance >= costFastDescent)
            {
                location += 2;
                endurance -= costFastDescent;
                endurance += plusEndurance;
            }
            else
                Relax();
        }

        public abstract void SpecialAction();

        public void Relax()
        {
            if (endurance < MaxEndurance)
            {
                endurance += plusEndurance;
                endurance += 3;
            }
            else
                endurance = MaxEndurance;
        }

        public void Stay()
        {
            if (endurance < MaxEndurance)
            {
                endurance += plusEndurance;
            }
            else
                endurance = MaxEndurance;
        }
    }
}
