using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day20_Sorting
    {
        /* 
        Given an array, A , of size N distinct elements, sort the array in ascending order using the Bubble Sort algorithm. 
        Once sorted, print the following  lines:

        1. "Array is sorted in numSwaps swaps." <-- where numSwaps is the number of swaps that took place.

        2. "First Element: firstElement" <-- where firstElement is the first element in the sorted array.

        3. "Last Element: lastElement" <-- where lastElement is the last element in the sorted array.
         
        */

        public void BubbleSort()
        {
            int n = 4; // array Length
            int[] a = new int[4] { 3, 2, 1, 4};
            
            int totalSwaps = 0;

            for (int i = 0; i < n; i++)
            {
                // number of swaps for current array iteration
                int numSwaps = 0;

                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int tmp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tmp;
                        numSwaps++;
                        totalSwaps++;
                    }
                }

                if (numSwaps == 0)
                {
                    Console.WriteLine($"Array is sorted in {totalSwaps} swaps.");
                    Console.WriteLine($"First Element: {a[0]}");
                    Console.WriteLine($"Last Element: {a[n - 1]}");
                    break;
                }
            }
        }

    }
}
