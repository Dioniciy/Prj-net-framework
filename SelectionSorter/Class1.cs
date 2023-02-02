using ISorterNS;
using System;
using System.Diagnostics;

namespace SelectionSorterNS
{
    public class SelectionSorter : ISorter
    {
        int[] data;
        int lenD;
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
        public void Sort()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //Console.WriteLine(Show() + " start");
            int j = 0;
            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                j = i;
                for (int k = i; k < lenD; k++)
                {
                    if (data[j] > data[k])
                    {
                        j = k;
                    }
                }
                tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;
            }
           // Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
            OnProcessCompleted();
        }
        public string Show()
        {
            return "Selection sorter";
        }
        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            if (ProcessCompleted != null)
            {
                ProcessCompleted?.Invoke();
            }
        }
    }
}
