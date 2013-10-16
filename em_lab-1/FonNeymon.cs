using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabChM1
{
    class FonNeymon:IGenerator
    {
        Converter converter;
        long seed;
        long nextValue;
        public FonNeymon(long value, int countOfNumbers)
        {
            seed = value;
            nextValue = nextRandom(value, value, countOfNumbers);
        }
        public long nextRandom(long value1, long value2, int countOfNumbers)
        {
            int ob = 0;
            int otsekSleva = 0;
            int otsekSprava = 0;
            long newValue = 0;
            converter = new Converter();
            long val = value1 * value2;
            List<long> list = new List<long>();
            list = converter.getArrayFromValue(val);
            ob = list.Count - countOfNumbers;
            otsekSleva = ob / 2;
            if (list[otsekSleva] == 0)
                list[otsekSleva] += 1;
            for (int i = 0; i < otsekSleva; i++)
            {
                list.RemoveAt(0);
            }
            otsekSprava = ob - otsekSleva;
            while (list.Count != countOfNumbers)
            {
                list.RemoveAt(countOfNumbers);
            }
            newValue = converter.getValueFromArray(list);
            nextValue = newValue;
            return newValue;
        }
        public long getSeed()
        {
            return seed;
        }
        public long getNext()
        {
            return nextValue;
        }
    }
}