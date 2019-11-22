using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {

            // BirthdayCakeCandles
            int[] numbers = new int[5] { 3, 3, 1, 3, 2};
            var candles = new BirthdayCakeCandles();
            candles.BirthdayCakeCandlesMethod(numbers);

            // Staircase
            //var staircase = new Staircase();
            //staircase.StaircaseMethod();


            //PlusMinus
            //var plusMinus = new PlusMinus();
            //plusMinus.PlusMinusMethod();


            //CompareTriplets
            //var compare = new CompareTheTriplets();
            //var result = compare.CompareTriplets();
            //Console.WriteLine(String.Join(" ", result)); 


            // ArraySum
            //var array = new int[] { 4, 1, 4, 3, 6};

            //var arraySum = new ArraySum();
            //var result = arraySum.ArraySumMethod(array);

            //Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
