using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicsLib.characters;

namespace LogicsLib
{
    public class Game
    {
        public object Player1 { get; set; }
        public object Player2 { get; set; }
        public Game(int p1, int p2)
        {
            switch (p1)
            {
                case 1:
                    this.Player1 = new ManMagic();
                    break;
                case 2:
                    this.Player1 = new DwarfWarrior();
                    break;
                case 3:
                    this.Player1 = new ElfScout();
                    break;
            }
            switch (p2)
            {
                case 1:
                    this.Player2 = new ManMagic();
                    break;
                case 2:
                    this.Player2 = new DwarfWarrior();
                    break;
                case 3:
                    this.Player2 = new ElfScout();
                    break;
            }
        }

        public Status getStatus(object player)
        {
            Status status = new Status();
            if (player is ManMagic)
            {
                status.Endurance = ((ManMagic)player).Endurance;
                status.Location = ((ManMagic)player).Location;
            }
            else if (player is DwarfWarrior)
            {
                status.Endurance = ((DwarfWarrior)player).Endurance;
                status.Location = ((DwarfWarrior)player).Location;
            }
            else if (player is ElfScout)
            {
                status.Endurance = ((ElfScout)player).Endurance;
                status.Location = ((ElfScout)player).Location;
            }

            return status;
        }

        public Status Relax(object player)
        {
            Status status = new Status();
            if (player is ManMagic)
            {
                ((ManMagic)player).Relax();
                Deadline = -1;
                status.Endurance = ((ManMagic)player).Endurance;
                status.Location = ((ManMagic)player).Location;
            }
            else if (player is DwarfWarrior)
            {
                ((DwarfWarrior)player).Relax();
                Deadline = -1;
                status.Endurance = ((DwarfWarrior)player).Endurance;
                status.Location = ((DwarfWarrior)player).Location;
            }
            else if (player is ElfScout)
            {
                ((ElfScout)player).Relax();
                Deadline = -1;
                status.Endurance = ((ElfScout)player).Endurance;
                status.Location = ((ElfScout)player).Location;
            }

            return status;
        }

        public Status Descent(object player)
        {
            Status status = new Status();
            if (player is ManMagic)
            {
                ((ManMagic)player).Descent();
                if (Deadline > 0 && ((ManMagic)player).Location >= Deadline)
                    ((ManMagic)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((ManMagic)player).Endurance;
                status.Location = ((ManMagic)player).Location;
            }
            else if (player is DwarfWarrior)
            {
                ((DwarfWarrior)player).Descent();
                if (Deadline > 0 && ((DwarfWarrior)player).Location >= Deadline)
                    ((DwarfWarrior)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((DwarfWarrior)player).Endurance;
                status.Location = ((DwarfWarrior)player).Location;
            }
            else if (player is ElfScout)
            {
                ((ElfScout)player).Descent();
                if (Deadline > 0 && ((ElfScout)player).Location >= Deadline)
                    ((ElfScout)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((ElfScout)player).Endurance;
                status.Location = ((ElfScout)player).Location;
            }

            return status;
        }

        public Status FastDescent(object player)
        {
            Status status = new Status();
            if (player is ManMagic)
            {
                ((ManMagic)player).FastDescent();
                if (Deadline > 0 && ((ManMagic)player).Location >= Deadline)
                    ((ManMagic)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((ManMagic)player).Endurance;
                status.Location = ((ManMagic)player).Location;
            }
            else if (player is DwarfWarrior)
            {
                ((DwarfWarrior)player).FastDescent();
                if (Deadline > 0 && ((DwarfWarrior)player).Location >= Deadline)
                    ((DwarfWarrior)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((DwarfWarrior)player).Endurance;
                status.Location = ((DwarfWarrior)player).Location;
            }
            else if (player is ElfScout)
            {
                ((ElfScout)player).FastDescent();
                if (Deadline > 0 && ((ElfScout)player).Location >= Deadline)
                    ((ElfScout)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((ElfScout)player).Endurance;
                status.Location = ((ElfScout)player).Location;
            }

            return status;
        }

        public Status SpecialAction(object player)
        {
            Status status = new Status();
            if (player is ManMagic)
            {
                ((ManMagic)player).SpecialAction();
                EventSA(player, getRival(player));
                Deadline = -1;
                status.Endurance = ((ManMagic)player).Endurance;
                status.Location = ((ManMagic)player).Location;
            }
            else if (player is DwarfWarrior)
            {
                ((DwarfWarrior)player).SpecialAction();
                EventSA(player, getRival(player));
                status.Endurance = ((DwarfWarrior)player).Endurance;
                status.Location = ((DwarfWarrior)player).Location;
            }
            else if (player is ElfScout)
            {
                ((ElfScout)player).SpecialAction();
                if (Deadline > 0 && ((ElfScout)player).Location >= Deadline)
                    ((ElfScout)player).location = Deadline - 1;
                Deadline = -1;
                status.Endurance = ((ElfScout)player).Endurance;
                status.Location = ((ElfScout)player).Location;
            }

            return status;
        }


        private int Deadline = -1;
        private void EventSA(object p1, object p2)
        {
            if (p1 is ManMagic)
            {
                if (p2 is DwarfWarrior)
                {
                    if (((ManMagic)p1).Location == ((DwarfWarrior)p2).Location)
                        ((DwarfWarrior)p2).location--;
                }
                else if (p2 is ElfScout)
                {
                    if (((ManMagic)p1).Location == ((ElfScout)p2).Location)
                        ((ElfScout)p2).location--;
                }
            }
            else if (p1 is DwarfWarrior)
            {
                if (p2 is ManMagic)
                {
                    if (((DwarfWarrior)p1).Location > ((ManMagic)p2).Location)
                    {
                        Deadline = ((DwarfWarrior)p1).Location;
                    }
                }
                else if (p2 is ElfScout)
                {
                    if (((DwarfWarrior)p1).Location > ((ElfScout)p2).Location)
                    {
                        Deadline = ((DwarfWarrior)p1).Location;
                    }
                }
            }
        }

        public void Stay(object player)
        {
            object rival = getRival(player);
            if (rival is ManMagic)
            {
                ((ManMagic)rival).Stay();
            }
            else if (rival is DwarfWarrior)
                ((DwarfWarrior)rival).Stay();
            else if (rival is ElfScout)
                ((ElfScout)rival).Stay();
        }

        private object getRival(object a)
        {
            if (a == Player1)
                return Player2;
            else
                return Player1;
        }




    }
}
