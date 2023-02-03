using System;

namespace ISorterNS
{
    public delegate void Notify(int progres, bool finished);
    public interface ISorter
    {

        void Attach(Notify observer);
        void SetSpeed(int delay);
        void Sort();
        string Show();
        void Init(int[] data, int lenD);
    }
}
