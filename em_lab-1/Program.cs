using System;
using System.Collections.Generic;

namespace em_lab_1
{
    class Program
    {
        static void Main()
        {
            IGenerator k = new LevisPayne(2378329262345678);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(k.getNext());
            }
            
        }
    }
}
