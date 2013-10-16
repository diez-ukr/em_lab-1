using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class MartinLusher : IGenerator
    {
        IGenerator marsalia;
        int marsalia_N; // kilikist chysel yaki budut zgenerovani metodom marsali
        int lusher_N; // kilkist chysel yaki budut vzyati
        List<long> numbers;
        int counter; // counter dlya toho shchob znaty koly treba zgeneruvaty novu poslidovnist metodom marsali

        public MartinLusher(McLarenMarsalia marsalia, int marsalia_N, int lusher_N)
        {
            this.marsalia_N = marsalia_N;
            this.lusher_N = lusher_N;
            this.marsalia = marsalia;
            counter = 0;
        }

        private void generateMarsaliaNumbers()
        {
            numbers = new List<long>();
            for (int i = 0; i < marsalia_N; i++)
                numbers.Add(marsalia.getNext());
            counter = lusher_N;
        }

        public long getSeed()
        {
            return getNext();
        }

        public int getPeriod(List<long> numbers)
        {
            int period;
            for (int i = 0; i < numbers.Count(); i++) {
                for (int j = i + 1; j < numbers.Count(); j++){
                    int seq_len = 0;
                    for (seq_len = 0; seq_len < 3 && i + seq_len < numbers.Count && seq_len + j < numbers.Count; seq_len++){
                        if (numbers[i + seq_len] != numbers[j + seq_len])
                           break;

                    }
                    if (seq_len == 3 - 1){
                        for (;seq_len >= 0; seq_len--)
                            return j - i;

                    }
                    
                }
            }
            return -1;
        }

        public long getNext()
        {
            if (counter == 0)
            {
                generateMarsaliaNumbers();
            }
            long nextNumber = numbers.First();
            numbers.Remove(numbers.First());
            counter--;
            return nextNumber;
        }
    }
}
