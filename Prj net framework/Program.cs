using System;

using ISorterNS;
using SelectionSorterNS;
using BubbleSorterNS;
using InsertionSorterNS;
using MergeSorterNS;
using QuickSorterNS;

namespace Prj_net_framework
{
    internal class Program
    {        
        static int Main(string[] args)
        {
            if(args.Length<3)
            {
                Console.Write("A few arguments ");
                Console.ReadKey();
                return 0;
            }
            ISorter selectionSorter = new SelectionSorter();
            ISorter bubbleSorter = new BubbleSorter();
            ISorter insertionSorter = new InsertionSorter();
            ISorter mergeSorter = new MergeSorter();
            ISorter quickSorter = new QuickSorter();
            string readBuffer;
   
            
            uint lng;
            if(uint.TryParse(args[0], out lng) == false || lng == 0)
            {
                Console.Write("Enter lengh of array again. ");
                Console.ReadKey();
                return 0;
            }

            uint height; 
            if (uint.TryParse(args[1], out height) == false || height == 0)
            {
                Console.Write("Enter height of array again. ");
                Console.ReadKey();
                return 0;
            }
                        
            int[,] array = new int[height, lng];
            if (args.Length-2 < lng*height)
            {
                Console.Write("A few arguments ");
                Console.ReadKey();
                return 0;
            }
            for (int i = 0; i < height; i++)
            {                   
                for(int k = 0; k < lng; k ++)
                {            
                    if (Int32.TryParse(args[2 + (i*lng) + k], out array[i, k]) == false)
                    {
                        Console.Write($"Enter element {k} in row {i} again. ");
                        Console.ReadKey();
                        return 0;
                    }   
                }
            }
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("////////////////////////////////////");
                Console.WriteLine();
                Console.WriteLine("Select sort method: \n 1. Selection sort \n 2. Bubble sort \n 3. Insertion sort \n 4. Merge sort \n 5. Quick sort");
                Console.WriteLine("__________________________________");
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
                    Console.WriteLine("            ");
                    for (int i = 0; i < lng; i++)
                    {
                        Console.Write($"  {array[j, i]},");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine();
                Console.WriteLine("__________________________________");             
            }
            
        }
    }
}
