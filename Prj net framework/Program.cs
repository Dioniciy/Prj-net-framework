using System;

using ISorterNS;
using SelectionSorterNS;
using BubbleSorterNS;
using InsertionSorterNS;
using MergeSorterNS;
using QuickSorterNS;
using System.Collections.Generic;

namespace Prj_net_framework
{
    internal class Program
{       
        static List<ISorter> sorters = new List<ISorter>();
        static ISorter selectionSorter = new SelectionSorter();
        static ISorter bubbleSorter = new BubbleSorter();
        static ISorter insertionSorter = new InsertionSorter();
        static ISorter mergeSorter = new MergeSorter();
        static ISorter quickSorter = new QuickSorter();

        static uint lng;
        static uint height;
        static int[,] array;
        static bool arrayCreated = false;
        static bool arraySizeEntered;
        static uint menuElement = 0;
        static string[] outArgs;
        static bool useDefaultData;
        static void Main(string[] args)
        {
            outArgs = args;
            InitList();

            while (true)
            {
                Start();                     
            }
        }
        
        static void Start()
        {
            ShowMenu();
            SelectMenuElement(ReadUintNumber());
            if (arrayCreated == false && arraySizeEntered == true)
            {
                array = new int[height, lng];
                arrayCreated = true;
                if (useDefaultData)
                {
                    SelectMenuElement(3);
                }
                else
                {

                    SelectMenuElement(1);
                }
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Select next step");
            Console.WriteLine("1. Enter array");
            Console.WriteLine("2. Select method");
            Console.WriteLine("3. Use defoult array");
            Console.Write("Your choose: ");
        }
        static void ShowMethods()
        {
            sorters.ForEach(method => Console.WriteLine(sorters.IndexOf(method) + 1 + ". " + method.Show()));
            Console.Write("Your choose: ");
        }

        static uint ReadUintNumber()
        {
            uint readNum;
            string readBuffer = Console.ReadLine();
            while (true)
            {
                if (uint.TryParse(readBuffer, out readNum) == true)
                {
                    return readNum;
                }
                else
                {
                    Console.Write("Enter number again: ");
                    readBuffer = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }
        static int ReadIntNumber()
        {
            int readNum;
            string readBuffer = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(readBuffer, out readNum) == true)
                {
                    return readNum;
                }
                else
                {
                    Console.Write("Enter number again: ");
                    readBuffer = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
        }
        static void InitList()
        {
            sorters.Add(selectionSorter);
            sorters.Add(bubbleSorter);
            sorters.Add(insertionSorter);
            sorters.Add(mergeSorter);
            sorters.Add(quickSorter);
        }

        static void SetArraySize(out uint lng, out uint height )
        {
            Console.WriteLine("===================");
            Console.WriteLine("Start creating...");
            Console.WriteLine("");

            Console.Write("Enter lengh of array: ");
            lng = ReadUintNumber();
            Console.Write("Enter height of array: ");
            height = ReadUintNumber();           
        }
        static void InitArray(int[,] array, bool useDefaultData = default)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Start initialisation...");
            Console.WriteLine("");
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    if (useDefaultData == true)
                    {
                        if (int.TryParse(outArgs[lng*i + k + 2], out array[i, k]) == false)
                        {
                            array[i, k] = 0;
                        }
                    }
                    else
                    {
                        Console.Write("Enter one arrays element and press enter: ");
                        array[i, k] = ReadIntNumber();
                    }
                    
                }
            }
            Console.WriteLine("===================");
            Console.WriteLine("Array inited ");
            Console.WriteLine("===================");

        }
        static void SelectMenuElement(uint elementNumber)
        {
            switch(elementNumber)
            {
                case 1:
                    if (useDefaultData == true)
                    {
                        useDefaultData = false;
                        arrayCreated = false;
                    }                   
                    if (arrayCreated == false)
                    {
                        SetArraySize(out lng, out height);
                        arraySizeEntered = true;
                    }
                    else
                    {
                        InitArray(array);
                    }                  
                    break;
                case 2:
                    if (arrayCreated == true)
                    {
                        ShowMethods();                        
                        SelectMethod(ReadIntNumber());
                        ShowArray();
                    }
                    else
                    {
                        Console.WriteLine("Array is empty ");
                    }
                    break;
                case 3:
                    if (useDefaultData == false)
                    { 
                        useDefaultData = true;
                        arrayCreated = false;
                    }
                    
                    if (arrayCreated == false)
                    {
                        if (uint.TryParse(outArgs[0], out lng) == false)
                        {
                           Console.Write("Not valid data for lengh");
                        }
                        if (uint.TryParse(outArgs[1], out height) == false)
                        {
                           Console.Write("Not valid data for height");
                        }                       
                        arraySizeEntered = true;  
                    }
                    else
                    {
                        InitArray(array, useDefaultData);
                    }
                    break;
            }
        }

        static void SelectMethod(int num)
        {
            if (num > 0) { num--; }
            int[] buff_arr = new int[lng * height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    buff_arr[lng * j + i] = array[j, i];
                }
            }
            sorters[num].Sort(buff_arr, lng * height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    array[j, i] = buff_arr[lng * j + i];
                }
            }
        }

        static void ShowArray()
        {
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
