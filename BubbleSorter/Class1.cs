using ISorterNS;

namespace BubbleSorterNS
{
    public class BubbleSorter : ISorter
    {
        public void Sort(int[] data, uint lenD)
        {
            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                for (uint j = (lenD - 1); j >= (i + 1); j--)
                {
                    if (data[j] < data[j - 1])
                    {
                        tmp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = tmp;
                    }
                }
            }
        }
    }
}
