using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    interface IGenerator
    {
        protected long seed;
        protected long x;
        public long getSeed();
        public long getNext();
        public IGenerator(long seed);
    }
}
