using ISorterNS;
using System;
using System.Diagnostics;

namespace MergeSorterNS
{
    public class MergeSorter : ISorter
    {
        int[] data;
        int lenD;
        int delay;
        bool finished = false;
        int progres = 0;
        event Notify ProcessCompleted;
        public void Attach(Notify observer)
        {
            ProcessCompleted += observer;
        }
        public void Init(int[] data, int lenD)
        {
            this.data = data;
            this.lenD = lenD;
        }
        public void SetSpeed(int delay)
        {
            this.delay = delay;
        }
        public void Sort()
        {
            finished = false;
            progres = 0;
            OnProcessUpdate();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine(Show() + " start");
            Sort(data, lenD);
            Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
            finished = true;
            progres = 100;
            OnProcessUpdate();
        }
        public void Sort(int[] data, int lenD)
        {
            if (lenD > 1)
            {
                int middle = lenD / 2;
                int rem = lenD - middle;
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
                System.Threading.Thread.Sleep(delay);
            }
            
        }
        void merge(int[] merged, int lenD, int[] L, int lenL, int[] R, int lenR)
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
        protected virtual void OnProcessUpdate() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            if (ProcessCompleted != null)
            {
                ProcessCompleted?.Invoke(progres, finished);
            }
        }
    }
}
