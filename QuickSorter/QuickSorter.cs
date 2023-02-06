using ISorterNS;
using System;
using System.Diagnostics;

namespace QuickSorterNS
{
    public class QuickSorter : ISorter
    {
        int[] data;
        int lng;
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
            this.lng = lenD;
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
            Sort(data, lng);            
            Console.WriteLine(Show() + $" complete after {timer.ElapsedMilliseconds} ");
            timer.Stop();
            finished = true;
            progres = 100;
            OnProcessUpdate();
        }
        public void Sort(int[] data, int len)
        {
            if (delay == 100) { return; };
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
 System.Threading.Thread.Sleep(delay/10);
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


