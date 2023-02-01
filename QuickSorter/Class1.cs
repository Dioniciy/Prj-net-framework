using ISorterNS;
using System;
using System.Diagnostics;

namespace QuickSorterNS
{
    public class QuickSorter : ISorter
    {
        int[] data;
        int lenD;
        public void Init(int[] data, int lenD)
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
        public void Sort(int[] data, int len)
        {
            int lenD = len;
            int pivot = 0;
            int ind = lenD / 2;
            int i, j = 0, k = 0;
            if (lenD > 1)
            {
                int[] l = new int[lenD];
                int[] r = new int[lenD];
                pivot = data[ind];
                for (i = 0; i < lenD; i++)
                {
                    if (i != ind)
                    {
                        if (data[i] < pivot)
                        {
                            l[j] = data[i];
                            j++;
                        }
                        else
                        {
                            r[k] = data[i];
                            k++;
                        }
                    }
                }
                Sort(l, j);
                Sort(r, k);
                for (int cnt = 0; cnt < lenD; cnt++)
                {
                    if (cnt < j)
                    {
                        data[cnt] = l[cnt]; ;
                    }
                    else if (cnt == j)
                    {
                        data[cnt] = pivot;
                    }
                    else
                    {
                        data[cnt] = r[cnt - (j + 1)];
                    }
                }
            }
        }
        public string Show()
        {
            return "Quick sorter";
        }
    }
}


