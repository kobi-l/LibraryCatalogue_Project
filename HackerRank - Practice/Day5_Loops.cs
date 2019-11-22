using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    public class Day5_Loops
    {
        public void LoopsMethod()
        {
            Console.Write("Please enter a number: ");

            var input = Int32.TryParse(Console.ReadLine(), out int number);
            Console.WriteLine("Here is the result: ");

            for (int i = 1; i < 11; i++)
            {
                var result = number * i;
                Console.WriteLine(number + " x " + i + " = " + result);
            }
        }
    }
}
