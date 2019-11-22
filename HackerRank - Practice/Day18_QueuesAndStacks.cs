using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day18_QueuesAndStacks
    {
        // FIFO style <-- First IN First OUT

        public Queue Queue;

        // Making a queue instance
        public Day18_QueuesAndStacks()
        {
            Queue = new Queue();
        }

        public int Size()
        {
            return Queue.Count;
        }

        // Enqueuing
        public void Enqueue(string n)
        {
            Queue.Enqueue(n);
        }

        // Dequeuing <-- would remove and return an item from the beginning of the queue.
        public string Dequeu()
        {
            return (string)Queue.Dequeue();
        }

        // Peeking at first item <--returns First item in the queue.
        public string Peek()
        {
            return (string)Queue.Peek();
        }
    }
}
