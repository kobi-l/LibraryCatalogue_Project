using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolate
{
    class Program
    {
        public static readonly double TooHot = 185;  // is Final in jave the same as Readonly in c#
        public static readonly double TooCold = 160;

        public static void DrinkHotChocolate(double cocoaTemp)
        {
            if (cocoaTemp >= TooHot)
                throw new TooHotException();
            else if (cocoaTemp <= TooCold)
                throw new TooColdException();
        }
        static void Main(string[] args)
        {
            double currentCocoaTemp = 170;
            Boolean wrongTemp = true;

            while (wrongTemp)
            {
                try
                {
                    DrinkHotChocolate(currentCocoaTemp);
                    Console.WriteLine("That cocoa was good!");
                    wrongTemp = false;
                }
                catch (TooHotException)
                {
                    Console.WriteLine("THAT'S TOO HOT!");
                    currentCocoaTemp -= 5;
                }
                catch (TooColdException)
                {
                    Console.WriteLine("THAT'S TOO COLD! It's like the arctic!");
                    currentCocoaTemp += 5;
                }
                Thread.Sleep(2000);
            }

            Console.WriteLine("And it's gone.");
            Console.ReadKey();
        }
    }
}
