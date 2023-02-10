using System;

namespace ISorterNS
{
    public delegate void Notify(int progres, bool finished);
    public class SwapIndexArgsClass
    {
        public int firstElement;
        public int secondElement;
        public SwapIndexArgsClass(int firstElement, int secondElement)
        {
            this.firstElement = firstElement;
            this.secondElement = secondElement;
        }
    }

    public delegate void SwapDelegate(SwapIndexArgsClass args);
    public interface ISorter
    {
        event SwapDelegate SwapEvent; 
        void Attach(Notify observer);
        void SetSpeed(int delay);
        void Sort();
        string Show();
        void Init(int[] data, int lenD);
    }
}
