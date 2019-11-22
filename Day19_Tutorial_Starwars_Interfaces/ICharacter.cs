using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_Tutorial_Starwars_Interfaces
{
    public interface ICharacter
    {
        string Base { get; }
        void Attack();
        void Heal();
        string GetWeapon();
    }
}
