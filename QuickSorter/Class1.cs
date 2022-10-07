using ISorterNS;
namespace QuickSorterNS
{
    public class QuickSorter : ISorter
    {
        public void Sort(int[] data, uint len)
        {
            uint lenD = len;
            int pivot = 0;
            uint ind = lenD / 2;
            uint i, j = 0, k = 0;
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
    }
}


