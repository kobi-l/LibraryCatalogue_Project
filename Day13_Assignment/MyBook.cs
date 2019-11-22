using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_Assignment
{
    class MyBook : BookAbstract
    {
        private int BookPrice;
        public MyBook(string t, string a, int price) : base(t, a)
        {
            BookPrice = price;
        }
        public override void Display()
        {
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Author: {this.Author}");
            Console.WriteLine($"Price: {this.BookPrice}");
        }
    }
}
