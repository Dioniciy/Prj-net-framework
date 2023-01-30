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
    public class WorkClass: ISubject
    {
        static List<ReflectionSorter> sorters = new List<ReflectionSorter>();

        ServerLogic server = new ServerLogic();
        public InitLogic init = new InitLogic(ref array, ref lng, ref height);
        static public int lng;
        static public int height;
        static public int[,] array = new int[1000, 1000];
        public bool arrayInited = false;
        public bool arraySizeEntered;
       
        public string[] outArgs;
        public int useData;
        static private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public int GetHeight() { return (int)height; }
        public int GetLengh() { return (int)lng; }
        private List<IObserver> _observers = new List<IObserver>();

        private WorkClass() { }
        private static WorkClass _instance;
        public static WorkClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WorkClass();
            }
            return _instance;
        }
             
        // The subscription management methods.
        public void Attach(IObserver observer)
        {
            //Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            //Console.WriteLine("Subject: Detached an observer.");
        }

        // Trigger an update in each subscriber.
        public void Notify()
        {
            //Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
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

        
       
       


        
       
        public void InitFromDB(int[,] array)
        {
            ArrayTwoDimensional u = server.ReadFromDB();
            if(u != null)
            {
                int cnt = 0;
                if (u.Lng > 1 && u.Height > 1) { lng = u.Lng; height = u.Height; arrayInited = true; }
                else { arrayInited = false; }                     
                for (int i = 0; i < height; i++)
                {
                    for (int k = 0; k < lng; k++)
                    {
                        array[i, k] = GetNumberFromString(u.Data.Substring(cnt), ref cnt);
                    }
                }
            }         
        }
        public void SaveToDB()
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
            server.SaveToDB(arr_str, (int)height, (int)lng);
        }
        public void StartInitMethod(int useData)
        {
            switch (useData)
            {
                case 0:
                    //InitFromConsole(array);
                    break;
                case 1:
                    arrayInited = init.InitFromFile();
                    break;
                case 2:
                    arrayInited = init.InitFromRandomData(array);
                    break;
                case 3:
                    InitFromDB(array);
                    break;
                case 4:
                    arrayInited = init.InitFromArguments(outArgs);
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
