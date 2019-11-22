using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day9_Recursion
    {

        /*  What is Recursion? 
         *  A recursive function is a function that calls itself. 
         *  A function that calls another function is normal but 
         *  when a function calls itself then that is a recursive function.
         *  
         *  f(f(f(a))) --- a = 20
            f(a) = 5 + a
            f(20) = 5 + 20 = 25

            f(f(f(20))) --- f(f(25))

            f(25) = 5 + 25 = 30

            f(f(f(20))) --- f(f(25)) --- f(30)

            f(30) = 5 + 30 = 35

            f(f(f(20))) --- f(f(25)) --- f(30)

            Summation:
            summation of 5 is 5+4+3+2+1+0
            summation of 7 is 7+6+5+4+3+2+1

            Factorial:
            factorial of 5! is 5*4*3*2*1

            */

        // 5 summation 
        public int Summation(int number) // static means you don't have to create an instance of this function
        {
            // Base case <-- means we are at the end
            if (number <= 0)
            {
                return 0;
            }
            // Recursive case <-- means KEEP going
            else
            {
                return number + Summation(number - 1);
            }
        }

        // 4! factorial --> means 4*3*2*1 (multiplication)
        public int Factorial(int n)
        {
            // Base case
            if (n <= 1)
            {
                return 1;
            }
            // Recursive case
            else
            {
                // Factorial(4) = 4* factorial(3)
                // 4*3* factorial(2)
                // 4*3*2* factorial(1)
                // 4*3*2*1
                return n * Factorial(n - 1);
            }
        }

        // 5^3 = 5*5*5 <-- exponential
        public int Exponentiation(int n, int p)
        {
            // Base case
            if (p <= 0)
            {
                return 1;
            }
            // Recursive Case
            else
            {
                // 5* exponentiation(5, 2)
                // 5* exponentiation(5, 1)
                // 5* exponentiation(5, 0)
                // 5*5*5*1
                return n * Exponentiation(n, p - 1);
            }
        }
    }
}
