using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    public class Day11_2D_Arrays
    {
        // Hourglass sum -  the sum of an hourglass' values.
        // Task
        // Calculate the hourglass sum for every hourglass in array, then print the maximum hourglass sum.

        public void TwoDimentionalArray()
        {
            int[,] arrMultiDimentional = new int[6, 6]
            {
                { 1, 1, 1, 0, 0, 0},
                { 0, 1, 0, 0, 0, 0},
                { 1, 1, 1, 0, 2, 0},
                { 0, 0, 3, 4, 3, 0},
                { 0, 0, 0, 4, 0, 1},
                { 0, 0, 3, 4, 3, 0},
            };

            int[][] arr = new int[6][] 
            {
                new int[6]{ 1, 1, 1, 0, 0, 0},
                new int[6]{ 0, 1, 0, 0, 0, 0},
                new int[6]{ 1, 1, 1, 0, 2, 0},
                new int[6]{ 6, 5, 3, 4, 3, 0},
                new int[6]{ 0, 1, 0, 4, 0, 1},
                new int[6]{ 7, 5, 3, 4, 3, 0}
            };
            


            int sum = -10000;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    // [00] [01] [02]
                    //      [11]
                    // [20] [21] [22]

                    int currentSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                           + arr[i + 1][j + 1]
                           + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                    }
                }
            }
            Console.WriteLine(sum);
        }

    }
    /*
     */
}
