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
            ISorter selectionSorter = new SelectionSorter();
            ISorter bubbleSorter = new BubbleSorter();
            ISorter insertionSorter = new InsertionSorter();
            ISorter mergeSorter = new MergeSorter();
            ISorter quickSorter = new QuickSorter();
            
        while (true)
        {   
            Console.Write("Enter lengh of array: ");
            int lng = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height of array: ");
            int height = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{lng} + {height}");

            Console.WriteLine();
           // Console.WriteLine("////////////////////////////////////");
            Console.WriteLine();
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
           
         
                Console.WriteLine();
                Console.WriteLine("////////////////////////////////////");
                Console.WriteLine();
                Console.WriteLine("Select sort method: \n 1. Selection sort \n 2. Bubble sort \n 3. Insertion sort \n 4. Merge sort \n 5. Quick sort");

                Console.WriteLine("__________________________________");
                //Console.WriteLine(); 
                Console.Write("Your choose: ");
                int method = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("__________________________________");
                
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
                         selectionSorter.Sort(buff_arr, lng * height);
                        break;
                    case 2:
                        bubbleSorter.Sort(buff_arr, lng * height);
                        break;
                    case 3:
                        insertionSorter.Sort(buff_arr, lng * height);                    
                        break;
                    case 4:
                        mergeSorter.Sort(buff_arr, lng * height);                                            
                        break;
                    case 5:
                        quickSorter.Sort(buff_arr, lng * height);                      
                        break;
                }
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        array[j, i] = buff_arr[lng * j + i];
                    }
                }
                Console.WriteLine("----------------------------------");
                Console.WriteLine("              RESULT              ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        Console.Write($"       {array[j, i]},");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine();
                Console.WriteLine("__________________________________");
                
            }
            
        }
    }
}
