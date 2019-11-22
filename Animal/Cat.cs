using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Cat : AnimalAbstractClass
    {
        public Cat() : base (7)
        {
            Console.WriteLine("A cat has been created!");
        }

        public override void Eat()
        {
            Console.WriteLine("A cat is eating!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Cat is sleeping!");
        }

        public void Meow()
        {
            Console.WriteLine("A cat meows!");
        }

        public void Prance()
        {
            Console.WriteLine("A cat is prancing!");
        }
    }
}
