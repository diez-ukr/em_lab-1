using System;
using System.Collections.Generic;

namespace em_lab_1
{
    class Program
    {
        static void Main()
        {
            IGenerator k = new LevinMethod(-1234567L, 1000L);
            long i = 0;
            var seq = new SortedList<long,long>();
            long next = 0;
            
            try
            {
                for (int j = 0; i < 100; i++)
                {
                    Console.WriteLine(k.getNext());
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine(i + ") " + next + "; already was at " + seq[next]);
            }
            
            Console.ReadKey();
        }
    }
}
