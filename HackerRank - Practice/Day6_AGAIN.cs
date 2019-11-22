using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day6_AGAIN
    {
        public void Review()
        {
            int number = 2;

            string[] arrayWords = new string[number];
            arrayWords[0] = "Hacker";
            arrayWords[1] = "Rank";

            foreach (var word in arrayWords)
            {
                char[] array = word.ToCharArray();

                // Even
                for (int i = 0; i < word.Length; i+=2)
                    Console.Write(array[i]);

                Console.Write(' ');
                // Odd
                for (int i = 1; i < word.Length; i+=2)
                    Console.Write(array[i]);

                Console.WriteLine();
            }       
        }
    }
} 
