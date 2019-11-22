using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussions
{
    class BookClass // by default has Private access modifier!
    {
        public string Title { get; set; } // <-- Mutable field - means CAN change!
        public string Author { get; set; } // <-- Mutable field.

        public int Pages; // <-- Immutable field - means CANNOT change!

        /* String is immutable type
         * 
         * StringBuilder is mutable type - that means we are using the same memory location and keep on appending/modifying the stuff to one instance.
         */

        //Collections
        public List<string> ListBooks { get; set; }


        public BookClass(string title, string author)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = 300;
        }

        // Function is a without void and return something
        public string BookTitle()
        {
            if (Title == null)
                return String.Empty; 
            else
                return Title;
        }

        // Method same as function but it's VOID
        public void PrintTitle()
        {
            Console.WriteLine(this.Title);
        }

        // Interfaces
        // Class
        // Abstract class
        // Static class, static method, static field, property.
    }
}
