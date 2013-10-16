using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabChM1
{
    class Mokli: IGenerator
    {
        public List<int> newList = new List<int>();
        FonNeymon fonneymon = new FonNeymon();
        private long next;

        public Mokli(int value1, int value6)
        {
            next = nextRand(value1, value6);
        }
        public int nextRand(int value1,int value6)
        {
            long newValue=fonneymon.nextRandom(value1, value6);
            return (int)newValue;
        }
        public long getSeed()
        {
            return 0;
        }
        public long getNext()
        {
            return next;
        }
    }
}
