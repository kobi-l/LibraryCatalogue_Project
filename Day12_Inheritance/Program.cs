using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[2] { 30, 40 };

            var student = new Student("Sam", "Fox", 69789, scores);
            student.PrintPerson();
            Console.WriteLine($"Grade: {student.Calculate()}");

            Console.ReadLine();
        }
    }
}
