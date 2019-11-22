using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day2_Operators
    {
        public void Operators()
        {
            /* 
             * Calculate Meal Total with Tip and Tax
             */

            while (true)
            {
                // Input from console
                Console.Write("Please enter the meal cost: ");
                double meal_cost = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the tip percent: ");
                int tip_percent = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter the tax percent: ");
                int tax_percent = Convert.ToInt32(Console.ReadLine());

                // Or I'll just set it:
                //double meal_cost = Convert.ToDouble("12.34");
                //int tip_percent = Convert.ToInt32("20");
                //int tax_percent = Convert.ToInt32("8");

                var tip = meal_cost * tip_percent / 100;
                var tax = meal_cost * tax_percent / 100;

                var totalCost = meal_cost + tip + tax;

                var roundedTotal = (decimal)Math.Round(totalCost, 2);
                Console.WriteLine("Total cost with tax and tip: {0:C}", roundedTotal); //"{0:C} outputs dollar value, ex. $15.49.

                //Ask to play again:
                Console.Write("Would you like to calculate another meal? [Y or N]: ");
                //Get answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else
                    return;
            }
        }
    }
}
