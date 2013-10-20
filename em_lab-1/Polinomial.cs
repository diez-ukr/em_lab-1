using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class Polinomial: IGenerator
    {
        private long seed;
        private long x;
        private Random rnd;

        public Polinomial(long seed)
        {
            this.seed = seed;
            this.x = seed;
            rnd = new Random((int)seed);
        }
        public long getSeed()
        {
            return seed;
        }

        public long getNext()
        {
            int m = (int)Math.Pow(101, 3);
            long period;
            List<long> numbers = new List<long>();

            numbers.Add((long)rnd.Next(m));
            int i = 0;
            for(i = 0; ; ++i)
            {
                x = numbers[i];
                numbers.Add(((x*x)^x) % m);
                period = i / 10;
                if (period != 0) break;
            }
            return x;
        }
    }
}