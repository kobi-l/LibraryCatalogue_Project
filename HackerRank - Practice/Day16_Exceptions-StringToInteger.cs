using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank___Practice
{
    class Day16_Exceptions_StringToInteger
    {
        
        public void ParseStringToIntUsingTryCatch()
        {
            // Given
            string text = "534534";

            try
            {
                int nums = Int32.Parse(text);
                Console.WriteLine(nums);
            }
            catch
            {
                Console.WriteLine("Bad String.");
            }           
        }

    }
}
