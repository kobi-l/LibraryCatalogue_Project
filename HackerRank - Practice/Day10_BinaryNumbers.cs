using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    public class Day10_BinaryNumbers
    {
        /*
         *  BINARY! <-- 101010101
         *  There are only 10 types of people in the world: Those that understand Binary 
         *  and those that don't.
         *  
         *  '10' really means 2. There are two types!
         *  
         *  BOOLEan Values
         *  a. TRUE  <-- 1  ex. SkyBlue?   = 1
         *  b. FALSE <-- 0  ex. GrassPink? = 0
         *  
         *  Think of it as a light switch:
         *  ON/OFF switch --> ON = 1 , OFF = 0.
         *  
         *  WHAT IS BASE 10? <-- decimal number system... regular numbers.
         *  
         *  WHAT IS BASE 2? <-- binary number system that has 2 digits (0, 1).
         *
         */

        public void BinaryNumbersMethod()
        {
            // Convert to binary (base 2)
            int num = 13;
            var binaryNum = Convert.ToString(num, 2); //<-- returns 101

            // Convert to decimal number
            int value = Convert.ToInt32(binaryNum, 2); // <-- returns 5;

            Console.WriteLine(binaryNum);
            //Console.WriteLine(value);

            char[] toArray = binaryNum.ToCharArray();
            Console.WriteLine(toArray.Length);


            int currentConsecutiveCount = 0;
            int highestConsecutiveCount = 0;

            for (int i = 0; i < toArray.Length; i++)
            {
                if (toArray[i] == '1')
                {
                    currentConsecutiveCount++;
                }
                else
                {
                    if (currentConsecutiveCount > highestConsecutiveCount)
                        highestConsecutiveCount = currentConsecutiveCount;
                    currentConsecutiveCount = 0;
                }
            }

            Console.WriteLine($"Highest consecutive count (2) is { ((currentConsecutiveCount > highestConsecutiveCount) ? currentConsecutiveCount : highestConsecutiveCount)}.");


            if (currentConsecutiveCount > highestConsecutiveCount)
                highestConsecutiveCount = currentConsecutiveCount;

            Console.WriteLine($"Highest consecutive count (1) is {highestConsecutiveCount}.");

            //int parsed;
            //var parsedToInt = Int32.TryParse(binaryNum, out int parsed);


            // Get consecutive 1's:  5 is 101 , 13 is 1101
            //int count = 0;
            //int n = 13;

            //while (n != 0)
            //{
            //    n = n & (n << 1);
            //    count++;
            //}

            //Console.WriteLine(count);
            //return count;
        }
    }
}
