using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab-1
{
    class FonNeymon
    {
        Converter converter;
        /*
        передаете 2 числа,по-моему везде кроме Мокли они одинаковые,
        поэтому можете переделать функцию,которая будет принимать 2 арг.,
        value and countOfNumbers и вместо value1 and value2 подставить просто value.
        countOfNumbers - количество розрядов числе. желательно она должна совпадать с розрядностью value.
        */
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
            return newValue;
        }
    }
}
