using ISorterNS;
using System;
using System.Diagnostics;

namespace InsertionSorterNS
{
    public class InsertionSorter : ISorter
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
            Console.WriteLine(Show() + " start");
            int key = 0;
            int i = 0;
            for (int j = 1; j < lenD; j++)
            {
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
            OnProcessCompleted();
        }
        public string Show()
        {
            return "Insertion sorter";
        }
        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            if(ProcessCompleted !=null)
            {
                ProcessCompleted?.Invoke();
            }           
        }       
    }
}
