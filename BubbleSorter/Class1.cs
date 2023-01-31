using ISorterNS;
using System;
using System.Diagnostics;

namespace BubbleSorterNS
{
    public class BubbleSorter : ISorter
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
            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                for (int j = (lenD - 1); j >= (i + 1); j--)
                {
                    if (data[j] < data[j - 1])
                    {
                        tmp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = tmp;
                    }
                }
            }
            Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
        }
        public string Show()
        {
            return "Bubble sorter";
        }

    }
}
