using ISorterNS;
using System;
using System.Diagnostics;

namespace BubbleSorterNS
{
    public class BubbleSorter : ISorter
    {
        int[] data;
        int lenD;
        int delay = 0;
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
            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                if (i > (lenD * progres / 100))
                {
                    progres += 10;
                    OnProcessUpdate();
                }
                System.Threading.Thread.Sleep(delay);
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
            finished = true;
            progres = 100;
            OnProcessUpdate();
        }
        public string Show()
        {
            return "Bubble sorter";
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
