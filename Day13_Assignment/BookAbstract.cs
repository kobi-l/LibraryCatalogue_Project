using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_Assignment
{
    public abstract class BookAbstract
    {
        protected string Title;
        protected string Author;

        public BookAbstract(string t, string a)
        {
            Title = t;
            Author = a;
        }

        public abstract void Display();
    }
}
