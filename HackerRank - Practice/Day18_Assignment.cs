using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day18_Assignment
    {
        Stack<char> Stack = new Stack<char>();
        Queue<char> Queue = new Queue<char>();

        //public Day18_Assignment()
        //{
        //    this.Stack = new Stack<char>();
        //    this.Queue = new Queue<char>();
        //}

        public void PushCharacter(char ch)
        {
            Stack.Push(ch);
        }

        public void EnqueueCharacter(char ch)
        {
            Queue.Enqueue(ch);
        }

        public char PopCharacter()
        {
            return this.Stack.Pop();
        }

        public char DequeueCharacter()
        {
            return this.Queue.Dequeue();
        }
    }
}
