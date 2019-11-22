using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Dog : AnimalAbstractClass
    {
        
        public Dog() : base(15)
        {
            Console.WriteLine("A dog has been created");
        }

        public override void Eat()
        {
            Console.WriteLine("A dog is eating!");
        }
         
        public override void Sleep()
        {
            //base.Sleep();
            Console.WriteLine("Dog is sleeping!");
        }

        public void Ruff()
        {
            Console.WriteLine("The dog says ruff!");
        }

        public void Run()
        {
            Console.WriteLine("A dog is running!");
        }

    }
}
