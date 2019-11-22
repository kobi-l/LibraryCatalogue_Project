using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class BirthdayCakeCandles
    {
        /* Assignment: 
            You are in charge of the cake for your niece's birthday and have decided the cake will 
            have one candle for each year of her total age. When she blows out the candles, 
            she’ll only be able to blow out the tallest ones. Your task is to find out 
            how many candles she can successfully blow out.
        */

        public int BirthdayCakeCandlesMethod(int[] array)
        {
            var highestNumber = array.Max();
            var count = array.Count(element => element == highestNumber); // <-- great way to increment count! and this is the same as 
            // block of code below:


            // this Foreach can be replaced with one line of code listed above!!!
            //int count = 0;
            //foreach (var element in array)
            //{
                
            //    if (element == highestNumber)
            //        count++;
            //}

            Console.WriteLine($"Candles blown: {count}");
            return count;
        }
    }
}
