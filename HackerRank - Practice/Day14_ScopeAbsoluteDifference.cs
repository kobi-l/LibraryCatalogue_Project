using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day14_ScopeAbsoluteDifference
    {

        private int[] Elements;
        public int MaximumDifference;

        public Day14_ScopeAbsoluteDifference(int[] array)
        {
            Elements = array;
        }

        public int ComputeDifference() => MaximumDifference = Elements.Max() - Elements.Min();
    }
}
