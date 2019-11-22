using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    /* Staircase out of # symbols
        
        Sample input: 4
        Sample output:
           #
          ##
         ###
        ####
    */
    public class Staircase
    {
        public void StaircaseMethod()
        {
            var number = 6;

            for (int i = 0; i < number; i++)
                Console.WriteLine(new String('#', i + 1).PadRight(number, ' '));

            // or use PadLeft to pad to the left side.
        }
    }
}
