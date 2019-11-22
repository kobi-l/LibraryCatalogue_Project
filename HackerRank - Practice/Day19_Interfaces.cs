using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    public class Day19_Interfaces
    {
        public int DivisorSum(int n)
        {
            int sum = 0;

            for (int i = 1; i*i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (i != n / i) sum += i;
                    sum += (n / i);
                }
            }
            Console.WriteLine(sum);
            return sum;
        }
    }
}

