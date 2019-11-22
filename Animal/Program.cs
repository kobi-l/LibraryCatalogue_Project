using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();

            dog.Ruff();
            Console.WriteLine(dog.GetAge());
            cat.Meow();
            Console.WriteLine(cat.GetAge());
            dog.Eat();
            dog.Sleep();
            cat.Eat();
            cat.Sleep();
            dog.Run();
            cat.Prance();

            Console.WriteLine();

            // Casting:
            Object dogA = new Dog();            
            var realDog = (Dog)dogA;
            realDog.Ruff();

            Object str = "string";
            var realStr = (string)str;

            // What happens when...
            Dog doggy = new Dog();
            if (doggy.GetType() == typeof(AnimalAbstractClass))
            {
                AnimalAbstractClass animal = (AnimalAbstractClass)doggy;
                animal.Sleep();
            }
            doggy.Sleep();


            Console.ReadLine();
        }
    }
}
