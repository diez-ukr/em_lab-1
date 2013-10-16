using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class Mokli: IGenerator
    {
        public List<int> newList = new List<int>();
        FonNeymon fonneymon;
        long val1;
        long val6;
        private long next;

        public Mokli(int value1, int value6)
        {
            fonneymon = new FonNeymon(value1, value6, 5);
            val1 = value1;
            val6 = value6;
        }
        public int nextRand(int value1,int value6)
        {
            long newValue=fonneymon.getNext();
            return (int)newValue;
        }
        public long getSeed()
        {
            return 0;
        }
        public long getNext()
        {
            next = nextRand((int)val1, (int)val6);
            val1 = next;
            return next;
        }
    }
}
