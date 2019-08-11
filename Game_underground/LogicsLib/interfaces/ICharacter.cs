using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsLib.interfaces
{
    public interface ICharacter
    {
        // выносливость
        int Endurance { get; }

        // местоположение персонажа
        int Location { get; }

        // спуск
        void Descent();

        // быстрый спуск
        void FastDescent();

        // особое действие
        void SpecialAction();

        // отдых
        void Relax();
    }
}
