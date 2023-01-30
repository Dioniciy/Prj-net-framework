using System;
using System.Threading;

using System.Reflection;
using ISorterNS;

using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Data.Entity;

using System.Runtime.Remoting.Contexts;
using System.Globalization;
using System.Data.SqlClient;


namespace WorkClassNS
{
    public class WorkClass
    {
        static List<ReflectionSorter> sorters = new List<ReflectionSorter>();
        

        static public uint lng;
        static public uint height;
        static public int[,] array = new int[1000, 1000];
        public bool arrayInited = false;
        public bool arraySizeEntered;
        Random rnd = new Random();
        public string[] outArgs;
        public int useData;
        static private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string path = "./input data.txt";
        public int GetHeight() { return (int)height; }
        public int GetLengh() { return (int)lng; }



        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private WorkClass() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static WorkClass _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static WorkClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WorkClass();
            }
            return _instance;
        }

       
        public class ArrayTwoDimensional
        {
            public int Id { get; set; }
            public int Lng { get; set; }
            public int Height { get; set; }
            public string Data { get; set; }
        }
        
        class ArrayContext : DbContext
        {
            public ArrayContext()
                : base("DbConnection")
            { }

            public DbSet<ArrayTwoDimensional> Arrays { get; set; }
        }

        class ReflectionSorter
        {
            public object ObjectSorter { get; set; }
            public MethodInfo MethodInfoSort { get; set; }
            public MethodInfo MethodInfoInit { get; set; }
            public MethodInfo MethodInfoShow { get; set; }
        }
        public void LoadMethods()
        {
            sorters.Clear();
            string[] array = Directory.GetFiles("../../../dll", "*.dll");
            log.Info($"Exist {array.Length} dll files.");
            foreach (string file in array)
            {
                Assembly asm = Assembly.LoadFrom(file);

                Type[] types = asm.GetTypes();
                foreach (Type t in types)
                {
                    Type[] interfaces = t.GetInterfaces();
                    foreach (Type intf in interfaces)
                    {
                        if (intf == typeof(ISorter))
                        {
                            ConstructorInfo Constructor = t.GetConstructor(Type.EmptyTypes);
                            object ClassObject = Constructor.Invoke(new object[] { });
                            MethodInfo Init = t.GetMethod("Init");
                            MethodInfo Sort = t.GetMethod("Sort", new Type[] { });
                            MethodInfo Show = t.GetMethod("Show");
                            sorters.Add(new ReflectionSorter() { MethodInfoSort = Sort, MethodInfoInit = Init, MethodInfoShow = Show, ObjectSorter = ClassObject });
                            break;
                        }
                    }
                }
            }
        }
        public void Start()
        {
            ShowMenu();
            SelectMenuElement(ReadUintNumber());

        }
        public void ShowMenu()
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
        public void ShowMethods()
        {
            LoadMethods();
            Console.WriteLine("0. Start all ");
            sorters.ForEach(method => Console.WriteLine(sorters.IndexOf(method) + 1 + ". " + method.MethodInfoShow.Invoke(method.ObjectSorter, parameters: null)));
            Console.Write("Your choose: ");
        }
        public string[] GetNamesMethods()
        {
            LoadMethods();
            Console.WriteLine("0. Start all ");
            string[] buff; 
            buff = new string[sorters.Count];
            for(int i = 0; i < sorters.Count; i++)
            {
                buff[i] = sorters[i].MethodInfoShow.Invoke(sorters[i].ObjectSorter, parameters: null).ToString();
            }
            //sorters.ForEach(method => [Console.WriteLine(sorters.IndexOf(method) + 1 + ". " + method.MethodInfoShow.Invoke(method.ObjectSorter, parameters: null)));
            return buff;
        }
        //static 

        public uint ReadUintNumber()
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
        public int ReadIntNumber()
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
        public void SetArraySize(out uint lng, out uint height)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Start creating...");
            Console.WriteLine("");

            Console.Write("Enter lengh of array: ");
            lng = ReadUintNumber();
            Console.Write("Enter height of array: ");
            height = ReadUintNumber();
        }
        public void InitArray(int[,] array, int useData = 0)
        {
            //Console.WriteLine("===================");
            //Console.WriteLine("Start initialisation...");
            //Console.WriteLine("");
            //switch (useData)
            //{
            //    case 0:
            //        InitFromConsole(array);
            //        arrayInited = true;
            //        break;
            //    case 1:
            //        InitFromArguments();
            //        arrayInited = true;
            //        break;
            //    case 2:
            //        InitFromFile(array);
            //        arrayInited = true;
            //        break;
            //    case 3:
            //        InitFromRandomData(array);
            //        arrayInited = true;
            //        break;
            //    case 4:
            //        InitFromDB(array);
            //        break;

            //}

            //Console.WriteLine("===================");
            //Console.WriteLine("Array inited ");
            //Console.WriteLine("===================");
        }
        public void InitFromConsole(int[,] array)
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

        public void InitFromArguments()
        {
            if (outArgs == null) { arrayInited = false;  return; }
            if (uint.TryParse(outArgs[0], out lng) == false)
            {
                log.Info("Invalid data for lengh!");
                lng = 10;
            }
            if (uint.TryParse(outArgs[1], out height) == false)
            {
                log.Info("Invalid data for height!");
                height = 10;
            }
            
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
            arrayInited = true; 
        }
        public int InitArray(string[,] data, int __height, int __lng)
        {
            if (__lng > 1) {  lng = (uint)__lng;}
            else {arrayInited = false; return 0;  }
            if (__height > 1) { height = (uint)__height;}
            else {arrayInited = false; return 0;  }
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    if (int.TryParse(data[i,k], out array[i, k]) == false)
                    {
                        log.Info("Invalid data for element!");
                        array[i, k] = 0;
                    }
                }
            }
            arrayInited=true;
            return 1;
        }
        public void InitFromFile(int[,] array)
        {
            string line = "";
            
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
            string[] buff = line.Split(' ');
            if (uint.TryParse(buff[0], out lng) == false)
            {
                arrayInited = false;
                log.Info("Can`t convert string from file to int!");
                return;
            }
            if (uint.TryParse(buff[1], out height) == false)
            {
                arrayInited = false;
                log.Info("Can`t convert string from file to int!");
                return ;
            }
            
            if (lng < 2) { lng = 10; }
            if (height < 2) { height = 10; }

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    if (int.TryParse(buff[height*i + k+2], out array[i, k]) == false)
                    {
                        array[i, k] = 0;
                        log.Info("Can`t convert string from file to int!");
                    }                 
                }
            }
            arrayInited = true;
        }

        public void InitFromRandomData(int[,] array)
        {
            
            lng = (uint)rnd.Next(2, 100);
            height = (uint)rnd.Next(2, 20);

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    array[i, k] = rnd.Next(1000);
                }
            }
            arrayInited = true;
        }
        public void InitFromDB(int[,] array)
        {
            int cnt = 0;
            using (ArrayContext db = new ArrayContext())
            {
                db.Database.CreateIfNotExists();
                db.Database.Initialize(false);
                DbSet<ArrayTwoDimensional> arrays = db.Arrays;
                foreach (ArrayTwoDimensional u in arrays)
                {
                    if ((uint)u.Lng > 1 && (uint)u.Height > 1) { lng = (uint)u.Lng; height = (uint)u.Height; arrayInited = true; }
                    else { arrayInited = false; }                     
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
        public void SaveToDB()
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
        public void StartInitMethod(int useData)
        {
            switch (useData)
            {
                case 0:
                    //InitFromConsole(array);
                    break;
                case 1:
                    InitFromFile(array);
                    break;
                case 2:
                    InitFromRandomData(array);
                    break;
                case 3:
                    InitFromDB(array);
                    break;
                case 4:
                    InitFromArguments();
                    break;

            }
        }
        
    public void SelectMenuElement(uint elementNumber)
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
                        SelectSortMethod(ReadIntNumber());
                        //ShowArray();
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
                        //ShowArray();
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
                        SaveToDB();
                    }
                    break;
            }
        }
        delegate void MessageHandler(string message);
        static public void SortFunc(object someObj)
        {
            if (someObj is ReflectionSorter obj)
            {
                obj.MethodInfoSort.Invoke(obj.ObjectSorter, parameters: null);
            }
        }
        public void SelectSortMethod(int num = 0)
        {
            if (!arrayInited) { return; }
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
            switch (num)
            {
                case 0:
                    int count = 0;
                    foreach (var sorter in sorters)
                    {
                        sorter.MethodInfoInit.Invoke(sorter.ObjectSorter, new object[] { buff_arr, lng * height });
                        myThreads.Add(new Thread(new ParameterizedThreadStart(SortFunc)));
                    }
                    foreach (var thread in myThreads)
                    {
                        thread.Start(sorters[count]);
                        count++;
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
                    //sorters[num].Init(buff_arr, lng * height);
                    //sorters[num].Sort();
                    sorters[num].MethodInfoInit.Invoke(sorters[num].ObjectSorter, new object[] { buff_arr, lng * height });
                    sorters[num].MethodInfoSort.Invoke(sorters[num].ObjectSorter, parameters: null);
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

        public string[,] GetDataAsStringArray()
        {
            string [,] buffer = new string[height,lng];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    buffer[j,i] =array[j, i].ToString();
                }                
            }

            return buffer;
        }
        public void ShowArrayToConsole()
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
