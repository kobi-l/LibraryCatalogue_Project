using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    public abstract class AnimalAbstractClass
    {

        private int Age;
        public AnimalAbstractClass(int age)
        {
            Age = age;
            Console.WriteLine("An animal has been created!");
        }
        public abstract void Eat();

        public virtual void Sleep()
        {
            Console.WriteLine("An animal is sleeping!");
        }

        //{
            //Console.WriteLine("An animal is eating");
        //}

        public int GetAge()
        {
            return Age;
        }
    }
}
