using ISorterNS;

namespace SelectionSorterNS
{
    public class SelectionSorter : ISorter
    {
        int[] data;
        uint lenD;
        public void Init(int[] data, uint lenD)
        {
            this.data = data;
            this.lenD = lenD;
        }
        public void Sort()
        {
            int j = 0;
            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                j = i;
                for (int k = i; k < lenD; k++)
                {
                    if (data[j] > data[k])
                    {
                        j = k;
                    }
                }
                tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;
            }
        }
        public string Show()
        {
            return "Selection sorter";
        }
    }
}
