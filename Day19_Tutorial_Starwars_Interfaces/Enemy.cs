using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_Tutorial_Starwars_Interfaces
{
    class Enemy : AbstractClass
    {
        public string Weapon = "Lightsaber";
        public Enemy()
        {

        }

        public override string GetWeapon()
        {
            return Weapon;
        }
        
        public override void Attack()
        {
            Console.WriteLine("The enemy attackts YOU!!!");
        }

        public override void Heal()
        {
            Console.WriteLine("The enemy heals himself.");
        }

        public void DrawWeapon()
        {
            Console.WriteLine("Draw out weapon!");
        }
    }
}
