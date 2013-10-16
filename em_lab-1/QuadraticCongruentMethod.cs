using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class QuadraticCongruentMethod : IGenerator
    {
        private long seed;
        private long modulus;
        private long currentX;
        private long a;
        private long d;
        private long c;

        public QuadraticCongruentMethod(long _seed, long _a, long _d, long _c, long _modulus)
        {
            seed = _seed;
            currentX = _seed;
            modulus = _modulus;
            a = _a;
            d = _d;
            c = _c;
        }

        public long getSeed()
        {
            return seed;
        }

        public long getNext()
        {
            currentX = (d * currentX * currentX + a * currentX + c) % modulus;
            return currentX;
        }
    }
}
