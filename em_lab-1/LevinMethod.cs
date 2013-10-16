using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class LevinMethod : IGenerator
    {
        private long seed;
        private long modulus;
        private long currentX;
        private long t;

        public LevinMethod(long _seed, long _modulus)
        {
            seed = _seed;
            currentX = _seed;
            modulus = _modulus;
            t = GenerateConstant();
        }

        public long getSeed()
        {
            return seed;
        }

        public long getNext()
        {
            currentX = currentX * currentX % modulus;
            return currentX * ScalarMutiplexBinary(currentX, t) % 2;
        }

        private long ScalarMutiplexBinary(long operand1, long operand2)
        {
            long logicalAnd = operand1 & operand2;
            long scalarMultiplex = 0;
            while(logicalAnd != 0)
            {
                scalarMultiplex += logicalAnd & 1;
                logicalAnd = logicalAnd >> 1;
            }
            return scalarMultiplex;
        }

        private long GenerateConstant()
        {
            Random rand = new Random();
            long randomSeed = rand.Next();
            long operand = (1 << (int)Math.Log(modulus, 2) + 1) - 1;
            return randomSeed & operand;
        }
    }
}
