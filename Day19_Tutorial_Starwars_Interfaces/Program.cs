using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_Tutorial_Starwars_Interfaces
{
    public class Program
    {
        public static ICharacter SummonCharacter()
        {
            Random rand = new Random();
            if (Math.Abs(rand.Next()) % 2 == 0)
                return new Enemy();
            else
                return new Hero();
        }

        static void Main(string[] args)
        {
            var darthVader = new Enemy();
            var ObiWanKenobi = new Hero();

            darthVader.Attack();
            ObiWanKenobi.Attack();

            darthVader.Heal();
            ObiWanKenobi.Heal();

            Console.WriteLine($"Enemy weapon: {darthVader.GetWeapon()}");
            Console.WriteLine($"Hero weapon: {ObiWanKenobi.GetWeapon()}");

            var spy = SummonCharacter();
            spy.Attack();
            spy.Heal();

            Console.ReadLine();
        }
    }
}
