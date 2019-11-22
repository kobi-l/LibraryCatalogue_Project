using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day3_IntroConditionalStatements
    {
        public void IntroConditionalStatements()
        {
            /*
            Ever or Odd numbers: 
            '%' is a remainder operator. if you take a number and devide it by 2 and there is no remainder (remainder == 0), 
            then it's an EVEN number. ex 10 / 2 = 5.

            if you take a number and devide it by 2 and there is a remainder (remainder == 1), 
            then it's an ODD number. ex 5 / 2 = 4 and there is remainer of 1.
            */

            Console.Write("Please enter a number: ");
            int N = Convert.ToInt32(Console.ReadLine());

            if (N % 2 != 0)
                Console.WriteLine("Weird");
            if (N % 2 == 0 && N >= 2 && N <= 5)
                Console.WriteLine("Not Weird");
            if (N % 2 == 0 && N >= 6 && N <= 20)
                Console.WriteLine("Weird");
            if (N % 2 == 0 && N > 20)
                Console.WriteLine("Not Weird");
        }
    }
}
