using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new MyBook("Happy Potter", "J.K Rowling", 99);
            book.Display();

            Console.ReadKey();
        }
    }
}
