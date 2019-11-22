using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class CompareTheTriplets
    {
        public List<int> CompareTriplets()
        {

            var a = new int[] { 17, 28, 30 };
            var b = new int[] { 99, 16, 8 };

            int resultOne = 0;
            int resultTwo = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    resultOne++;
                }

                if (a[i] < b[i])
                {
                    resultTwo++;
                }
            }

            return new List<int>() { resultOne, resultTwo }; // <-- returns '2 1'

            // OR make class VOID and write to console:
            //Console.Write(resultOne);
            //Console.Write(" ");
            //Console.Write(resultTwo);
        }
    }
}