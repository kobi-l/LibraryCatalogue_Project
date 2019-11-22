using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussions
{
    class Program
    {
        
        static void Main(string[] args) // <-- never changes! Starting point!
        {

            var stringBuilter1 = new StringBuilder("Your Total amount is "); // <-- with text
            var stringBuilter2 = new StringBuilder(20); // <-- with allocating memory for 20 characters

            decimal amount = 35.99m;

            Console.WriteLine(stringBuilter1.AppendFormat("{0:C} ", amount));
            Console.WriteLine(stringBuilter1.Append("forth line"));
            Console.WriteLine(stringBuilter1);
            //var checkoutB = new Program();
            //checkoutB.CheckoutBook();

            Console.ReadLine();
        }

        public void CheckoutBook()
        {

        }

        public int NumberOfBooks()
        {
            return 0;
        }

        public string BookTitle()
        {
            return String.Empty;
        }

        public bool TrueOrFalse()
        {
            return false;
        }

        public decimal GetDecimalNum()
        {
            return 4m;
        }

        public double GetDoubleNum()
        {
            return 4.0;
        }
    }
}
