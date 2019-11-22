using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Inheritance
{
    public class Student : Person
    {
        private int[] TestScores;
        public Student(string firstName, string lastName, int identification, int[] testScores) : base(firstName, lastName, identification)
        {
            TestScores = testScores;
        }

        public char Calculate()
        {
            int average = 0;
            for (int i = 0; i < TestScores.Length; i++)
            {
                average += TestScores[i];
            }
            average = average / TestScores.Length;

            if (average >= 90 && average <= 100)
                return 'O';
            else if (average >= 80 && average < 90)
                return 'E';
            else if (average >= 70 && average < 80)
                return 'A';
            else if (average >= 55 && average < 70)
                return 'P';
            else if (average >= 40 && average < 55)
                return 'D';
            else
                return 'T';
        }
    }
}
