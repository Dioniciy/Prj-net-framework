using ISorterNS;

namespace InsertionSorterNS
{
    public class InsertionSorter : ISorter
    {
        public void Sort(int[] data, uint lenD)
        {
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
        }
    }
}
