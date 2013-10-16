using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class FibonacciMethod : IGenerator
    {
        long seed;
        int m = 51;              // m - число нужно, когда мы по формуле делаем (блаблабла mod m) - задаем руками, как хотим

        public FibonacciMethod(long seed)
        {
            this.seed = seed;
        }

        public long getSeed()
        {
            return seed;
        }

        public long getNext()   
        {
            Random random = new Random();
            long [] x = new long[2];
            long result;

            x[0] = (long)random.Next();     // генерируем первые два 
            x[1] = (long)random.Next();     // числа последовательности (нужны для формулы)

            result = (x[1] + x[0]) % m;

            return result;
        }
    }
}
