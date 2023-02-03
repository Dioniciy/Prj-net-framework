using ISorterNS;
using System;
using System.Diagnostics;

namespace InsertionSorterNS
{
    public class InsertionSorter : ISorter
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
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine(Show() + " start");
            int key = 0;
            int i = 0;
            for (int j = 1; j < lenD; j++)
            {
                if (i > (lenD * progres / 100))
                {
                    progres += 10;
                    OnProcessUpdate();
                }
                System.Threading.Thread.Sleep(delay);
                key = data[j];
                i = j - 1;
                while (i >= 0 && data[i] > key)
                {
                    data[i + 1] = data[i];
                    i = i - 1;
                    data[i + 1] = key;
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
            return "Insertion sorter";
        }
        protected virtual void OnProcessUpdate() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            if(ProcessCompleted !=null)
            {
                ProcessCompleted?.Invoke(progres, finished);
            }           
        }       
    }
}
