using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day6_LetsReview
    {
        
        public void LetsReviewMethod()
        {
            Console.Write("Please enter a number: ");

            int inputNum = int.Parse(Console.ReadLine());

            string[] wordsArray = new string[inputNum];


            for(int i = 0; i < wordsArray.Length; i++)
            {
                if (i == 0)
                    Console.WriteLine("Please give me a word.");
                else
                    Console.WriteLine("Please give me another word.");

                wordsArray[i] = Console.ReadLine();
            }
            foreach (var word in wordsArray)
            {
                var charactersArray = word.ToCharArray();

                for (int i = 0; i < charactersArray.Length; i += 2)
                {
                    Console.Write(charactersArray[i]);
                }

                Console.Write(' ');

                for (int i = 1; i < charactersArray.Length; i += 2)
                {
                    Console.Write(charactersArray[i]);
                }
                Console.WriteLine();
            }
        }

        public void ReviewEasierWay()
        {
            int number = 2;

            string[] arrayWords = new string[number];
            arrayWords[0] = "Hacker";
            arrayWords[1] = "Rank";

            foreach (var word in arrayWords)
            {
                char[] charArray = word.ToCharArray();

                // Even:
                for (int i = 0; i < charArray.Length; i += 2)
                {
                    Console.Write(charArray[i]);
                }

                Console.Write(' ');
                // Odd:
                for (int i = 1; i < charArray.Length; i += 2)
                {
                    Console.Write(charArray[i]);
                }
                Console.WriteLine();
            }
        }
    }
}
