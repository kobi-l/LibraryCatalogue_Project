using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day17_MoreExceptions
    {
        public void Day17Power(int n, int p)
        {
            var day17 = new Day17_MoreExceptions();

            try
            {
                Console.WriteLine(day17.CalculatePower(n, p));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int CalculatePower(int n, int p)
        {
            // their version:
            //if (n < 0 || p < 0)
            //    throw new Exception("n and p should be non-negative");
            //else
            //    return (int)Math.Pow(n, p);

            //******

            // my version #1:
            if (n < 0 || p < 0)
                throw new Exception("n and p should be non-negative");
            return (int)Math.Pow(n, p);
        }
    }
}