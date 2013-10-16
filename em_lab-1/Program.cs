using System;
using System.Collections.Generic;

namespace em_lab_1
{
    class Program
    {
        static void Main()
        {
            IGenerator k = new Marsalli(163957472);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(k.getNext());
            }
            
        }
    }
}
