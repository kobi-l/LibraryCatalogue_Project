using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    public class Day7_Arrays
    {
        public void ReverseOutput()
        {
            //Reverse: Day 7!

            int[] madLibs = new int[3] { 1, 2, 3 };

            Array.Reverse(madLibs);

            var output = string.Empty;

            foreach (var item in madLibs)

                output = string.Concat(output, item, ' ');

            Console.WriteLine(output.Trim());
        }
    }
}
