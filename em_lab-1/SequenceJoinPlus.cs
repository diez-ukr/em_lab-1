using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class SequenceJoinPlus : IGenerator
    {
        private long x;
        private long seed;
        private List<long> xList;
        private IGenerator yGenerator;

        public SequenceJoinPlus(List<long> xList, IGenerator yGenerator, long seed)
        {
            this.xList = xList;
            this.yGenerator = yGenerator;
            this.x = xList[(int)(Math.Abs(seed) % xList.Count)];
        }

        public SequenceJoinPlus(IGenerator xGenerator, long xLength, IGenerator yGenerator, long seed)
        {
            this.yGenerator = yGenerator;
            this.seed = seed;
            this.xList = new List<long>();
            while (xLength > 0)
            {
                xList.Add(xGenerator.getNext());
                xLength--;
            }
            this.x = xList[(int)(Math.Abs(seed) % xList.Count)];
        }

        public long getSeed()
        {
            return this.seed;
        }

        public long getNext()
        {
            this.x = xList[(int)Math.Abs((this.x + yGenerator.getNext()) % xList.Count)];
            return this.x;
        }
    }
}
