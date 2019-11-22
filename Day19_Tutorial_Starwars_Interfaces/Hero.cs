
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_Tutorial_Starwars_Interfaces
{
    class Hero : AbstractClass
    {
        public string Weapon = "The Force";

        public override string GetWeapon()
        {
            return Weapon;
        }

        public override void Attack()
        {
            Console.WriteLine("The hero attackts enemy!!!");
        }

        public override void Heal()
        {
            Console.WriteLine("The hero heals YOU!!!");
        }

        public void DrawWeapon()
        {
            Console.WriteLine("Draw out weapon!");
        }
    }
}
