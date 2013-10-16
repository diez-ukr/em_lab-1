using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class KoveyMethod : IGenerator
    {
        private long x;
        private long seed;
        private int l;

        public KoveyMethod(long seed, int l)
        {
            this.x = seed;
            this.seed = seed;
            this.l = l;
        }

        public long getNext()
        {
            this.x = this.x * (this.x + 1) % (long)Math.Pow(2, l);
            return this.x;
        }

        public long getSeed()
        {
            return seed;
        }
    }
}
