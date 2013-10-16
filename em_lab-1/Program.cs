using System;
using System.Collections.Generic;

namespace em_lab_1
{
    class Program
    {
        static void Main()
        {
            IGenerator k = new KnutMethod(-1234567L);
            long i = 0;
            var seq = new SortedList<long,long>();
            long next = 0;
            
            try
            {
                while (true)
                {
                    next = k.getNext();
                    seq.Add(next, i);
                    i++;
                    if (i % 1000 == 0)
                        Console.WriteLine(i / 1000 + " * 10^3...");
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
