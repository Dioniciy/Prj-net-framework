using System;
using System.Threading;


using ISorterNS;
using SelectionSorterNS;
using BubbleSorterNS;
using InsertionSorterNS;
using MergeSorterNS;
using QuickSorterNS;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Data.Entity;

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
        static int[,] array = new int[1000, 1000];
        static bool arrayInited = false;
        static bool arraySizeEntered;

        static string[] outArgs;
        static int useData;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string path = "./input data.txt";
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class ArrayTwoDimensional
        {
            public int Id { get; set; }
            public int Lng { get; set; }
            public int Height { get; set; }
            public string Data { get; set; }
        }
        class UserContext : DbContext
        {
            public UserContext()
                : base("DbConnection")
            { }

            public DbSet<User> Users { get; set; }
        }
        class ArrayContext : DbContext
        {
            public ArrayContext()
                : base("DbConnection")
            { }

            public DbSet<ArrayTwoDimensional> Arrays { get; set; }
        }
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

        }
        static void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Select next step");
            Console.WriteLine("1. Enter array");
            Console.WriteLine("2. Select method");
            Console.WriteLine("3. Use defoult array");
            Console.WriteLine("4. Use data from file");
            Console.WriteLine("5. Use random data");
            Console.WriteLine("6. Show array");
            Console.WriteLine("7. Use data from DB");
            Console.WriteLine("8. Save data to DB");
            Console.Write("Your choose: ");
        }
        static void ShowMethods()
        {
            Console.WriteLine("0. Start all ");
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

        static void SetArraySize(out uint lng, out uint height)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Start creating...");
            Console.WriteLine("");

            Console.Write("Enter lengh of array: ");
            lng = ReadUintNumber();
            Console.Write("Enter height of array: ");
            height = ReadUintNumber();
        }
        static void InitArray(int[,] array, int useData = 0)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Start initialisation...");
            Console.WriteLine("");
            switch (useData)
            {
                case 0:
                    InitFromConsole(array);
                    break;
                case 1:
                    InitFromArguments(array);
                    break;
                case 2:
                    InitFromFile(array);
                    break;
                case 3:
                    InitFromRandomData(array);
                    break;
                case 4:
                    InitFromDB(array);
                    break;

            }
            arrayInited = true;
            Console.WriteLine("===================");
            Console.WriteLine("Array inited ");
            Console.WriteLine("===================");
        }
        static void InitFromConsole(int[,] array)
        {
            SetArraySize(out uint lng, out uint height);            
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    Console.Write("Enter one arrays element and press enter: ");
                    array[i, k] = ReadIntNumber();
                }
            }
        }

        static void InitFromArguments(int[,] array)
        {
   
            if (uint.TryParse(outArgs[0], out lng) == false)
            {
                Console.Write("");
                log.Info("Invalid data for lengh!");
                lng = 10;
            }
            if (uint.TryParse(outArgs[1], out height) == false)
            {
                log.Info("Invalid data for heifht!");
                height = 10;
            }
            
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int k = 0; k < lng; k++)
                    {
                        if (int.TryParse(outArgs[lng * i + k + 2], out array[i, k]) == false)
                        {
                            log.Info("Invalid data for element!");
                            array[i, k] = 0;
                        }
                    }
                }
            }
        }

        static void InitFromFile(int[,] array)
        {
            string line = "";
            int cnt = 0;
            StreamReader reader;

            if (!File.Exists(path))
            {
                try
                {
                    FileStream fs = File.Create(path);
                    Byte[] b = new UTF8Encoding(true).GetBytes("5 2 9 5 2 1 4 7 6 3 0 8");
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                }
                catch
                {
                    Console.WriteLine("File can`t created");
                }
            }
            reader = new StreamReader(path);
            line = reader.ReadLine();
            reader.Close();
            lng = (uint)GetNumberFromString(line, ref cnt);
            if (lng == 0) { lng = 10; }
            height = (uint)GetNumberFromString(line.Substring(cnt), ref cnt);
            if (height == 0) { height = 10; }

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    array[i, k] = GetNumberFromString(line.Substring(cnt), ref cnt);
                }
            }
        }

        static void InitFromRandomData(int[,] array)
        {
            Random rnd = new Random();
            lng = (uint)rnd.Next(2, 200);
            height = (uint)rnd.Next(2, 20);
         
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    array[i, k] = rnd.Next(1000);
                }
            }
        }
        static void InitFromDB(int[,] array)
        {
            int cnt = 0;
            using (ArrayContext db = new ArrayContext())
            {
                DbSet< ArrayTwoDimensional> arrays = db.Arrays;
                foreach (ArrayTwoDimensional u in arrays)
                {
                    lng = (uint)u.Lng;
                    height = (uint)u.Height;
                    for (int i = 0; i < height; i++)
                    {
                        for (int k = 0; k < lng; k++)
                        {
                            array[i, k] = GetNumberFromString(u.Data.Substring(cnt), ref cnt);
                        }
                    }
                    break;
                }
            }
        }
        static void SaveToDB(int[,] array)
        {
            using (ArrayContext db = new ArrayContext())
            {
                string arr_str = "";
                int[] buff_arr = new int[lng * height];
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < lng; i++)
                    {
                        arr_str = string.Concat(arr_str, array[j, i].ToString());
                        arr_str = string.Concat(arr_str, ' ');
                        //buff_arr[lng * j + i] = array[j, i];
                    }
                }

                ArrayTwoDimensional data = new ArrayTwoDimensional { Data = arr_str, Height = (int)height, Lng = (int)lng };
                db.Arrays.Add(data);
                db.SaveChanges();
            }
        }
        static void SelectMenuElement(uint elementNumber)
        {
            switch (elementNumber)
            {
                case 1:
                    if (useData != 0)
                    {
                        useData = 0;
                    }
                    InitArray(array, useData);

                    break;
                case 2:
                    if (arrayInited)
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

                    if (useData != 1)
                    {
                        useData = 1;
                    }
                    InitArray(array, useData);
                    break;
                case 4:
                    if (useData != 2)
                    {
                        useData = 2;
                    }
                    InitArray(array, useData);
                    break;
                case 5:
                    if (useData != 3)
                    {
                        useData = 3;
                    }
                    InitArray(array, useData);
                    break;
                case 6:
                    if (arrayInited)
                    {
                        ShowArray();
                    }
                    else
                    {
                        Console.WriteLine("Array is empty ");
                    }
                    break;
                case 7:
                    if (useData != 4)
                    {
                        useData = 4;
                    }
                    InitArray(array, useData);
                    break;
                case 8:
                    if (arrayInited)
                    {
                        SaveToDB(array);
                    }
                    break;
            }
        }

        static void SelectMethod(int num = 0)
        {

            if (num > sorters.Count) { return; }
            int[] buff_arr = new int[lng * height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    buff_arr[lng * j + i] = array[j, i];
                }
            }
            List<Thread> myThreads = new List<Thread>();
            //List<Stopwatch> timers = new List<Stopwatch>();
            switch (num)
            {
                case 0:
                    foreach (var sorter in sorters)
                    {
                        sorter.Init(buff_arr, lng * height);
                        myThreads.Add(new Thread(new ThreadStart(sorter.Sort)));
                        //timers.Add(new Stopwatch());
                        //= new Thread(new ThreadStart(sorter.Sort));
                        // myThread.Start();
                    }
                    foreach (var thread in myThreads)
                    {
                        thread.Start();
                    }
                    bool flag = true;
                    while (flag)
                    {
                        flag = false;
                        foreach (var thread in myThreads)
                        {
                            if (thread.ThreadState != System.Threading.ThreadState.Stopped)
                            {
                                flag = true;
                            }
                        }
                    }
                    break;
                default:
                    if (num > 0) { num--; }
                    sorters[num].Init(buff_arr, lng * height);
                    sorters[num].Sort();
                    break;
            }

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
        static int GetNumberFromString(string str, ref int charLng)
        {
            string numericString = "";
            bool flagStartNum = false;

            foreach (char c in str)
            {
                charLng++;
                if ((c >= '0' && c <= '9')) //|| c == ' ' || c == '-'
                {
                    if (!flagStartNum) { flagStartNum = true; }
                    numericString = string.Concat(numericString, c);
                }
                else if (flagStartNum)
                {
                    break;
                }
            }
            int number;
            if (int.TryParse(numericString, out number) == false)
            {
                number = 0;
                log.Info($"Can`t convert string {numericString} to int!");
            }
            return number;
        }
    }


}
