using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_Tutorial_Starwars_Interfaces
{
    class AbstractClass : ICharacter
    {
        public string Base => "character";

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public virtual void Heal()
        {
            throw new NotImplementedException();
        }

        public virtual string GetWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
