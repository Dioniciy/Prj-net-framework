using ISorterNS;
using System;
using System.Diagnostics;

namespace MergeSorterNS
{
    public class MergeSorter : ISorter
    {
        int[] data;
        uint lenD;
        public void Init(int[] data, uint lenD)
        {
            this.data = data;
            this.lenD = lenD;
        }
        public void Sort()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine(Show() + " start");
            Sort(data, lenD);
            Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
        }
        public void Sort(int[] data, uint lenD)
        {
            if (lenD > 1)
            {
                uint middle = lenD / 2;
                uint rem = lenD - middle;
                int[] L = new int[middle];
                int[] R = new int[rem];
                for (int i = 0; i < lenD; i++)
                {
                    if (i < middle)
                    {
                        L[i] = data[i];
                    }
                    else
                    {
                        R[i - middle] = data[i];
                    }
                }
                Sort(L, middle);
                Sort(R, rem);
                merge(data, lenD, L, middle, R, rem);
            }
            
        }
        void merge(int[] merged, uint lenD, int[] L, uint lenL, int[] R, uint lenR)
        {
            int i = 0;
            int j = 0;
            while (i < lenL || j < lenR)
            {
                if (i < lenL & j < lenR)
                {
                    if (L[i] <= R[j])
                    {
                        merged[i + j] = L[i];
                        i++;
                    }
                    else
                    {
                        merged[i + j] = R[j];
                        j++;
                    }
                }
                else if (i < lenL)
                {
                    merged[i + j] = L[i];
                    i++;
                }
                else if (j < lenR)
                {
                    merged[i + j] = R[j];
                    j++;
                }
            }
        }
        public string Show()
        {
            return "Merge sorter";
        }
    }
}
