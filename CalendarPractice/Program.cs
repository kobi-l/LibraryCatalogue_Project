using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new DateTime();
            var now = DateTime.UtcNow;
            calendar.AddDays(100);

            Console.WriteLine(calendar.AddDays(2));
            Console.WriteLine(now.AddDays(7));

            
            Console.ReadLine();
        }
    }
}
