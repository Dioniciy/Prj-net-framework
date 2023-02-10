using ISorterNS;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SelectionSorterNS
{
    public class SelectionSorter : ISorter
    {
        int[] data;
        int lenD;
        bool finished = false;
        int progres = 0;
        event Notify ProcessCompleted;
        public event SwapDelegate SwapEvent;
        int delay;
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
        void Swap(int src, int dst)
        {
            int buffer = data[dst];
            data[dst] = data[src];
            data[src] = buffer;

            if (SwapEvent != null)
            {
                SwapEvent.Invoke(new SwapIndexArgsClass(src, dst));
            }
        }
        public void Sort()
        {
            finished = false;
            progres = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //Console.WriteLine(Show() + " start");
            int j = 0;
            
            
            for (int i = 0; i < lenD; i++)
            {
                System.Threading.Thread.Sleep(delay);
                if (i > (lenD*progres/100))
                {
                    progres += 10;
                    OnProcessUpdate();
                }
                
                j = i;
                for (int k = i; k < lenD; k++)
                {
                    if (data[j] > data[k])
                    {
                        j = k;
                    }
                }
                Swap(i, j);
            }
           // Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
            finished = true;
            progres = 100;
            OnProcessUpdate();
        }
        public string Show()
        {
            return "Selection sorter";
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
