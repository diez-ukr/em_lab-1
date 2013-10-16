using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class Converter
    {
        public long getCountOfNumber(long value)
        {
            long sum=0;
            while (value > 0)
            {
                value = value / 10;
                sum += 1;
            }
            return sum;
        }

        public List<long> getArrayFromValue(long value)
        {
            long numOfNumbers = getCountOfNumber(value);
            List<long> list = new List<long>((int)numOfNumbers);
            for (int i = 0; i < numOfNumbers; i++)
            {
                list.Insert(0, value % 10);
                value /= 10;
            }
            return list;
        }

        public long getValueFromArray(List<long> array)
        {
            long value = 0;
            for (int i = 0; i < array.Count; i++)
            {
                value += (long)(array[i] * Math.Pow(10, (array.Count - i - 1)));
            }
            return (long)value;

        }

    }
}
