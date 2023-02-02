using System;

namespace ISorterNS
{
    public delegate void Notify();
    public interface ISorter
    {

        void Attach(Notify observer);
        void Sort();
        string Show();
        void Init(int[] data, int lenD);
    }
}
