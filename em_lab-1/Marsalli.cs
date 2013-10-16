using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class Marsalli : IGenerator
    {
        private long m = (long)Math.Pow(2, 23);
        private long seed;
        private List<long> buf = new List<long>(55); //First 55 elements
        public Marsalli(long seed)
        {
            this.seed = seed;
            for (int i = 0; i < 55; i++)  // Dohuya RANDOMLY fill first 55 elements
            {
                buf.Add(seed + i);
            }
        }
        public long getSeed()
        {
            return seed;
        }

        public long getNext()
        {
            long x = (buf[55 - 24] * buf[55 - 55]) % m;
            buf.RemoveAt(0);
            buf.Add(x);
            return x;
        }
    }
}
