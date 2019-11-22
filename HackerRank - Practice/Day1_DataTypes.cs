using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day1_DataTypes
    {

        public void DataTypes()
        {
            // Given 
            //int i = 4;
            //double d = 4.0;
            //string s = "HackerRank ";

            //// Declare second integer, double, and String variables and these will be coming in from a Console (Console.ReadLine())
            //int i2 = Convert.ToInt32("12");
            //double d2 = Convert.ToDouble("4.0");
            //string s2 = "is the best place to learn and practice coding!";

            //// Print the sum of both integer variables on a new line.
            //Console.WriteLine(i + i2);

            //// Print the sum of the double variables on a new line.
            //Console.WriteLine("{0:0.0}", d + d2); // <-- would display with zeros... ex. chagnes '8' to '8.0'.

            //// Concatenate and print the String variables on a new line
            //// The 's' variable above should be printed first.
            //Console.WriteLine(s + s2);


            // Own practice:
            Console.Write("Please enter a number: ");

            //var inputInt = Int32.TryParse(Console.ReadLine(), out int result);

            //OR
            var inputInt = Int32.TryParse(Console.ReadLine(), out int result);

            if (inputInt)
                Console.WriteLine(result + 6);
            else
                Console.WriteLine("Cannot Parse!");
        }
    }
}
