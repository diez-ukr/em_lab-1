using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class McLarenMarsalia : IGenerator
    {
        long seed;
        int r; // kilkist chysel yaki potribno zgeneruvaty spochatku
        long[] A; // masyv zgenerovanyh inshymy metodamy chysel
        List<long> xi, yi; // pochatkovi poslidovnosti
        long currentXi, currentYi;
        long my, mx; // maksymalni znachennya poslidovnostey yi, xi vidpovidno
        int j; // indeks nastupnogo randomnogo chysla
        IGenerator method1, method2; // metody dlya generacii pochatkovyh poslidovnostey xi, yi (ci metody povynni generuvaty dodatni chysla)
        Random rnd; // dlya generacii nastupnogo indeksa, po yakomy bude vzyato nastupnyi currentXi, currentYi

        public McLarenMarsalia(IGenerator method1, IGenerator method2, int r)
        {
            this.r = r;
            rnd = new Random();
            this.method1 = method1;
            this.method2 = method2;
            A = new long[r];
            generateXiYi();
            makePositive(yi, xi);
            my = yi.Max();
        }

        private void makePositive(List<long> y, List<long> x)
        {
            for (int i = 0; i < y.Count; i++)
            {
                y[i] = Math.Abs(y[i]);
                x[i] = Math.Abs(x[i]);
            }
        }

        private void generateXiYi()
        {
            xi = new List<long>();
            yi = new List<long>();
            for (int i = 0; i < r; i++)
            {
                xi.Add(method1.getNext());
                yi.Add(method2.getNext());
                A[i] = xi[i];
            }
        }

        private void updateCurrentXiYi()
        {
            currentXi = xi[rnd.Next(r)];
            currentYi = yi[rnd.Next(r)];
        }

        public long getSeed()
        {
            return currentYi;
        }

        // period = NSK periodiv vhidnyh poslidovnostey
        public int getT(int a, int b)
        {
            return a / gcd(a, b) * b;
        }

        private int gcd(int a, int b)
        {
            if (b == 0) 
                return a;
            return gcd(b, a % b);
        }

        public long getNext()
        {
            updateCurrentXiYi();
            j = (int)Math.Floor(Math.Abs((double)((r-1) * currentYi / my)));
            long nextNumber = A[j];
            A[j] = currentXi;
            return nextNumber;
        }
    }
}
