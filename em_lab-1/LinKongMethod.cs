using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class LinKongMethod
    {
        Converter converter;
        public LinKongMethod()
        {
            converter = new Converter();
        }
        public int nextRand(int a, int b, int c, int k0,int digit) //digit - система счисления. короче у меня пятирозрядные числа, я передая (a,b,99999,prev_value,5)
        {
            long newValue = 0;
            newValue = (a * k0 + b) % c;//все,что дальше делается для того,чтобы если сгенериться число меньшей розрядности чем есть,оно в конец просто 6 запишет)
            List<long> list = new List<long>();//знаю что можно int хуярить,но нужно весь код переписывать
            list = converter.getArrayFromValue(newValue);
            while (list.Count < digit)
            {
                list.Add(6);
            }
            newValue = converter.getValueFromArray(list);
            return (int)newValue;
        }
    }
}
