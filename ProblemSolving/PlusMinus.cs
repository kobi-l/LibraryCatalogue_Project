using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class PlusMinus
    {
        /*
         * Given an array of integers, 
         * calculate the fractions of its elements that are positive, 
         * negative, and are zeros. Print the decimal value of each fraction on a new line.
         * 
         * You must print the 3 following  lines:

            1. A decimal representing of the fraction of positive numbers in the array compared to its size.
            2. A decimal representing of the fraction of negative numbers in the array compared to its size.
            3. A decimal representing of the fraction of zeros in the array compared to its size.

            Sample iput:
            6
            -4 3 -9 0 4 1 

            Sample output:
            0.500000
            0.333333
            0.166667
         */


        public void PlusMinusMethod()
        {
            var intArr = new int[] { -4, 3, - 9, 0, 4, 1 };
            
            // #1 Positives
            //var positives = intArr.Where(p => p > 0).Count();

            //var decPos = Convert.ToDecimal(positives);
            //var decArr = Convert.ToDecimal(intArr.Length);
            //var posDecimal = decPos / decArr;
            //CalculateFraction(positives, intArr.Length);

            Console.WriteLine(CalculateFraction(intArr.Where(p => p > 0).Count(), intArr.Length));

            // #2 Negatives
            //var negatives = intArr.Where(p => p < 0).Count();

            //var decNeg = Convert.ToDecimal(negatives);
            //var negDecimal = decNeg / decArr;

            //Console.WriteLine("{0:0.000000}", negDecimal);
            Console.WriteLine(CalculateFraction(intArr.Where(p => p < 0).Count(), intArr.Length));


            // #3 Zeroes
            //var zeroes = intArr.Where(p => p == 0).Count();

            //var zeroNeg = Convert.ToDecimal(zeroes);
            //var zerDecimal = zeroNeg / decArr;

            //Console.WriteLine("{0:0.000000}", zerDecimal);
            Console.WriteLine(CalculateFraction(intArr.Where(p => p == 0).Count(), intArr.Length));
        }

        private static string CalculateFraction(decimal topNum, decimal bottomNum)
        {
            return String.Format("{0:0.000000}", topNum / bottomNum);
            //return topNum / bottomNum;
        }
    }
}
