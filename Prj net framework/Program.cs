using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_net_framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter lengh of array: ");
            int lng = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter height of array: ");
            int height = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{lng} + {height}");
            int[,] array = new int[height, lng];
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine($"Enter row {i}");
                string str = Console.ReadLine();
                string newStr = str.Replace(",", " ");
                int[] buffer = newStr.Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < lng; j++)
                {
                    array[i, j] = buffer[j];
                }
            }
            while (true)
            {
                Console.WriteLine("Select sort method: \n 1. Selection sort \n 2. Bubble sort \n 3. Insertion sort \n 4. Merge sort \n 5. Quick sort");
                int method = Convert.ToInt32(Console.ReadLine());
                int[] buff_arr = new int[lng * height];
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        buff_arr[lng * j + i] = array[j, i];
                    }
                }
                switch (method)
                {
                    case 1:
                        Selection_sort(buff_arr, lng * height);
                        break;
                    case 2:
                        Bubble_srt(buff_arr, lng * height);
                        break;
                    case 3:
                        Insertion_sort(buff_arr, lng * height);
                        break;
                    case 4:
                        Merge_sort(buff_arr, lng * height);
                        break;
                    case 5:
                        Quick_Sort(buff_arr, lng * height);
                        break;
                }
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        array[j, i] = buff_arr[lng * j + i];
                    }
                }
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        Console.Write($"{array[j, i]},");
                    }
                    Console.WriteLine("");
                }
            }
            void Selection_sort(int[] data, int lenD)
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
            void Bubble_srt(int[] data, int lenD)
            {
                int tmp = 0;
                for (int i = 0; i < lenD; i++)
                {
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
            }
            void Insertion_sort(int[] data, int lenD)
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
            void Merge_sort(int[] data, int lenD)
            {
                if (lenD > 1)
                {
                    int middle = lenD / 2;
                    int rem = lenD - middle;
                    int[] L = new int[middle];
                    int[] R = new int[rem];
                    for (int i = 0; i < lenD; i++)
                    {
                        if (i < middle)
                        {
                            L[i] = data[i];
                        }
                        else
                        {
                            R[i - middle] = data[i];
                        }
                    }
                    Merge_sort(L, middle);
                    Merge_sort(R, rem);
                    merge(data, lenD, L, middle, R, rem);
                }
            }


            void merge(int[] merged, int lenD, int[] L, int lenL, int[] R, int lenR)
            {
                int i = 0;
                int j = 0;
                while (i < lenL || j < lenR)
                {
                    if (i < lenL & j < lenR)
                    {
                        if (L[i] <= R[j])
                        {
                            merged[i + j] = L[i];
                            i++;
                        }
                        else
                        {
                            merged[i + j] = R[j];
                            j++;
                        }
                    }
                    else if (i < lenL)
                    {
                        merged[i + j] = L[i];
                        i++;
                    }
                    else if (j < lenR)
                    {
                        merged[i + j] = R[j];
                        j++;
                    }
                }
            }
            void Quick_Sort(int[] data, int len)
            {
                int lenD = len;
                int pivot = 0;
                int ind = lenD / 2;
                int i, j = 0, k = 0;
                if (lenD > 1)
                {
                    int[] L = new int[lenD];
                    int[] R = new int[lenD];
                    pivot = data[ind];
                    for (i = 0; i < lenD; i++)
                    {
                        if (i != ind)
                        {
                            if (data[i] < pivot)
                            {
                                L[j] = data[i];
                                j++;
                            }
                            else
                            {
                                R[k] = data[i];
                                k++;
                            }
                        }
                    }
                    Quick_Sort(L, j);
                    Quick_Sort(R, k);
                    for (int cnt = 0; cnt < lenD; cnt++)
                    {
                        if (cnt < j)
                        {
                            data[cnt] = L[cnt]; ;
                        }
                        else if (cnt == j)
                        {
                            data[cnt] = pivot;
                        }
                        else
                        {
                            data[cnt] = R[cnt - (j + 1)];
                        }
                    }
                }
            }
        }
    }
}
