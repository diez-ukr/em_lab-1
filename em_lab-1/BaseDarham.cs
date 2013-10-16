using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace em_lab_1
{
    class BaseDarham : IGenerator
    {
        long seed;
        int r; // kilkist chysel yaki potribno zgeneruvaty spochatku
        long[] A; // masyv zgenerovanyh inshym metodom chysel
        List<long> xi; // pochatkova poslidovnist
        long currentXi;
        long mx; // maksymalne znachennya poslidovnosti xi
        int j; // indeks nastupnogo rendomnogo chysla
        IGenerator method; // metod dlya generacii pochatkovoi poslidovnosti xi (metod povynen generuvaty dodatni chysla)
        Random rnd; // dlya generacii nastupnogo indeksa, po yakomy bude vzyato nastupnyi currentXi

        public BaseDarham(IGenerator method, int r)
        {
            this.r = r;
            rnd = new Random();
            this.method = method;
            A = new long[r];
            generateXi();
            makePositive(xi);
            mx = xi.Max();
        }

        private void makePositive(List<long> x)
        {
            for (int i = 0; i < x.Count; i++)
            {
                x[i] = Math.Abs(x[i]);
            }
        }

        private void generateXi()
        {
            xi = new List<long>();
            for (int i = 0; i < r; i++)
            {
                xi.Add(method.getNext());
                A[i] = xi[i];
            }
        }

        private void updateCurrentXi()
        {
            currentXi = xi[rnd.Next(r)];
        }

        public long getSeed()
        {
            return currentXi;
        }

        // the hardest method
        public int getT(int period)
        {
            return period;
        }

        public long getNext()
        {
            updateCurrentXi();
            j = (int)Math.Floor(Math.Abs((double)((r - 1) * currentXi / mx)));
            long nextNumber = A[j];
            A[j] = currentXi;
            return nextNumber;
        }
    }
}
