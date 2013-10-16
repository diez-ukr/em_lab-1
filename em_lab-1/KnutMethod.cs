using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace em_lab_1
{
    class KnutMethod : IGenerator
    {
        private class Digits
        {
            public List<byte> digits;
            private bool positive;

            public Digits(long value)
            {
                digits = new List<byte>();

                positive = true;
                if (value < 0)
                {
                    positive = false;
                    value = -value;
                }
                do
                {
                    digits.Insert(0, (byte)(value % 10));
                    value /= 10;
                } while (value != 0);
            }
            public long getValue()
            {
                long retval = 0;
                for (int i = 0; i < digits.Count; i++)
                {
                    retval *= 10;
                    retval += digits[i];
                }
                if (!positive)
                    retval *= -1;
                return retval;
            }
            public byte nextMax()
            {
                byte retval = this.digits[this.digits.Count - 1];
                this.digits.RemoveAt(this.digits.Count - 1);
                return retval;
            }
        }
        private long x;
        private long seed;

        public KnutMethod(long seed)
        {
            this.x = seed;
            this.seed = seed;
        }
        public long getSeed()
        {
            return seed;
        }
        public long getNext()
        {
            Digits currentDigits;
            Digits newDigits;
            Digits digits;

            digits = new Digits(this.x);
            byte counter = digits.nextMax();
            for (byte i = 0; i <= counter; i++)
            {
                switch (digits.nextMax() + 3)
                {
                    case 3:
                        if (this.x < 5000000000L)
                            this.x += 5000000000L;
                        goto case 4;
                    case 4:
                        this.x = ((long)Math.Floor((double)((this.x * this.x) / 100000L))) % 10000000000L;
                        goto case 5;
                    case 5:
                        this.x = (1001001001L * this.x) % 10000000000L;
                        goto case 6;
                    case 6:
                        if (this.x < 100000000L)
                            this.x += 9814055677L;
                        else
                            this.x = 10000000000L - this.x;
                        goto case 7;
                    case 7:
                        long first5 = this.x % 100000;
                        this.x = first5 * 100000 + (this.x / 100000);
                        goto case 8;
                    case 8:
                        this.x = (1001001001L * this.x) % 10000000000L;
                        goto case 9;
                    case 9:
                        currentDigits = new Digits(this.x);
                        for (int j = 0; j < currentDigits.digits.Count; j++)
                            if (0 != currentDigits.digits[j]) currentDigits.digits[j]--;
                        goto case 10;
                    case 10:
                        if (this.x < 100000L)
						    this.x = this.x * this.x + 99999L;
					    else
						    this.x -= 99999L;
                            goto case 11;
                    case 11:
                            while (this.x < 1000000000L)
                                this.x *= 10;
                            goto case 12;
                    case 12:
                            this.x = ((long)Math.Floor((double)((this.x * (this.x - 1)) / 100000L))) % 10000000000L;
                            digits = new Digits(this.x);
                            break;
                }
            }
            return this.x;
        }
    }

    
}


