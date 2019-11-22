using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day15_LinkedLists
    {
        public void LinkedLists()
        {
            int[] numArr1 = new int[] { 1, 2, 9 };
            string[] numArr2 = new string[] { "A", "B", "C", "D" };

            var linkedInts = new LinkedList<int>(numArr1);
            var linkedStr = new LinkedList<string>(numArr2);
            //var linkedNode = new LinkedListNode<int>(45);

            Console.WriteLine($"Numbers in array before: {linkedInts.Count}");
            linkedInts.AddFirst(1);
            linkedInts.AddLast(1);
            //linkedInts.AddAfter(numArr1[0], 5);
            //linkedInts.AddAfter(1, 5);

            Console.WriteLine($"Numbers in array after: {linkedInts.Count}");

            foreach (var item in linkedInts)
            {
                Console.Write(item + ", ");
            }

           // Console.WriteLine(result.Trim());

            // Solution for Day15 on the website
            //public static Node InsertNode(Node head, int data)
            //{
            //    if (head == null)
            //        return new Node(data);

            //    Node temp = head;
            //    while (temp.next != null)
            //        temp = temp.next;
            //    temp.next = new Node(data);

            //    return head;
            //}
        }
    }
}
