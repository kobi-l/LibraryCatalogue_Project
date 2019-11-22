using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var day20 = new Day20_Sorting();
            day20.BubbleSort();
            
            //var day19 = new Day19_Interfaces();
            //day19.DivisorSum(20);

            //******
            //// Day 18 - Is it a palindrome?
            //string s = "racecar";

            //var instance = new Day18_Assignment();

            //// push/enqueue all the characters of string s to stack.
            //foreach (char c in s)
            //{
            //    instance.PushCharacter(c);
            //    instance.EnqueueCharacter(c);
            //}

            //bool isPalindrome = true;

            //// pop the top character from stack.
            //// dequeue the first character from queue.
            //// compare both the characters.
            //for (int i = 0; i < s.Length / 2; i++)
            //{
            //    if (instance.PopCharacter() != instance.DequeueCharacter())
            //    {
            //        isPalindrome = false;

            //        break;
            //    }
            //}

            //// finally print whether string s is palindrome or not.
            //if (isPalindrome)
            //{
            //    Console.Write("The word, {0}, is a palindrome.", s);
            //}
            //else
            //{
            //    Console.Write("The word, {0}, is not a palindrome.", s);
            //}

            //******




            // Stacks:
            //var day18 = new Stack<string>();
            //day18.Push("there");
            //day18.Push("hi");

            //Console.Write(day18.Pop() + " ");
            //Console.WriteLine(day18.Peek());
            //Console.Write(day18.Pop() + "!");

            // Queues:
            //var day18 = new Day18_Queues();
            //day18.Enqueue("one");
            //day18.Enqueue("two");
            //day18.Enqueue("three");

            //Console.WriteLine($"First out: {day18.Dequeu()}");
            //Console.WriteLine($"Peek at second: {day18.Peek()}");
            //Console.WriteLine($"Second out: {day18.Dequeu()}");
            //Console.WriteLine($"Third out: {day18.Dequeu()}");



            //var day17 = new Day17_MoreExceptions();
            //day17.Day17Power(3, 5);
            //day17.Day17Power(-1, -2);
            //day17.Day17Power(-1, 3);
            //day17.Day17Power(0, 3);
            //day17.Day17Power(5, 0);


            //var day16 = new Day16_Exceptions_StringToInteger();
            //day16.ParseStringToIntUsingTryCatch();

            //var day15 = new Day15_LinkedLists();
            //day15.LinkedLists();


            // Day 14:
            //int[] numArr = new int[] { 1, 2, 9 };
            //var d = new Day14_ScopeAbsoluteDifference(numArr);
            //d.ComputeDifference();

            //Console.WriteLine(d.MaximumDifference);


            //var day11 = new Day11_2D_Arrays();
            //day11.TwoDimentionalArray();

            //var day10 = new Day10_BinaryNumbers();
            //day10.BinaryNumbersMethod();


            //var day9 = new Day9_Recursion();
            //Console.WriteLine(day9.Summation(10));
            //Console.WriteLine(day9.Factorial(10));
            //Console.WriteLine(day9.Exponentiation(5, 10));


            //var day8 = new Day8_DictionariesAndMaps();
            //day8.AddToDictionary();


            //var day7 = new Day7_Arrays();
            //day7.ReverseOutput();


            //var day6b = new Day6_AGAIN();
            //day6b.Review();

            //var day6 = new Day6_LetsReview();
            //day6.ReviewEasierWay();


            //var day5 = new Day5_Loops();
            //day5.LoopsMethod();


            //var day4 = new Day4_ClassVsInstance();
            //day4.AskForAge();


            //var day3 = new Day3_IntroConditionalStatements();
            //day3.IntroConditionalStatements();


            //var day2 = new Day2_Operators();
            //day2.Operators();


            //var day1 = new Day1_DataTypes();
            //day1.DataTypes();


            Console.ReadKey();
        }
    }
}
