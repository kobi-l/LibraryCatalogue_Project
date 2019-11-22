using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day4_ClassVsInstance
    {
        private int age;

        public void AmIOld()
        {
            Console.Write("Please enter your age: ");

            var inputAge = Int32.TryParse(Console.ReadLine(), out int ageEntered);
            // Add some more code to run some checks on initialAge
            if (ageEntered > 0)
            {
                age = ageEntered;
            }
            else
            {
                age = 0;
                Console.WriteLine("Age is not valid, setting age to 0.");
            }


            // Do some computations in here and print out the correct statement to the console 
            if (age < 13)
                Console.WriteLine("You are young.");
            else if (age >= 13 && age < 18)
                Console.WriteLine("You are a teenager.");
            else
                Console.WriteLine("You are old.");
        }

        public void AskForAge()
        {
            while (true)
            {
                AmIOld();

                // Ask to play again:
                Console.Write("Would you like to play again? [Y or N]: ");
                // Get answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {

                    //Console.Write("Please enter your age: ");
                    continue;
                }
                else
                    return;
            }
        } 

        public void YearPasses()
        {
            // Increment the age of the person in here
            age++;
        }
    }
}

