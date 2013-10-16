using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class Eychendauer_LemMethod : IGenerator
    {
        long seed;
        long a = 1012336746465;          //параметры, которые нужны для формулы
        long c = 92700;                 //можно задать 
        long p = 349000;                //руками
        long x;

        public Eychendauer_LemMethod(long seed)
        {
            this.seed = seed;
            this.x = seed;
        }

        public long getSeed()
        {
            return seed;
        }

        public long getNext()
        {
            if (this.x == 0)
            {
                Random r = new Random();
                x = r.Next();
            }
            else
            {

                this.x = (a * 1 / x + c) % p;
            }

            return x;
        }
    }
}
