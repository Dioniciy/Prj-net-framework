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
using System.ComponentModel;

namespace WorkClassNS
{
    public partial class WorkClass: ISubject
    {
        List<ISorter> sortersList;//= new List<ISorter>();
        int lng;
        int height;
        public   int[,] array = new int[1000, 1000];
        public bool arrayInited = false;
        public bool arraySizeEntered;
        public bool SortCompleted;
        public bool SwapActived = false;
        public int progres = 0;
        public string[] outArgs;
        //ServerLogic server = new ServerLogic();
        //public InitLogic init = new InitLogic();
        //ReflexionLogic reflex = new ReflexionLogic();
        public delegate void SetSpeedEvent(int delay);
        public static event SetSpeedEvent setSpeedEvente;
        public int useData;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SwapIndexArgsClass swapArgs = new SwapIndexArgsClass(0, 0);
        public int GetHeight() { return (int)height; }
        public int GetLengh() { return (int)lng; }
        public void SetSize(int height, int lng) { this.lng = lng; this.height = height; }
        private List<IObserver> _observers = new List<IObserver>();

        private WorkClass() { }
        private static  WorkClass _instance;
        public static WorkClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WorkClass();             
            }
            return _instance;
        }
        void SwapIvent(SwapIndexArgsClass args)
        {
            SwapActived = true;
            swapArgs = args;
            Notify();
            SwapActived = false;
        }
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
        public void ChangeSpeedEvent(int delay)
        {
            setSpeedEvente?.Invoke(delay );
        }
        void SortersProgresEvents(int progres, bool finished)
        {
            SortCompleted = finished;
            this.progres = progres;
            Notify();
        }
        void AddSorterssIvents()
        {
            foreach(ISorter sorter in sortersList)
            {
                sorter.Attach(SortersProgresEvents);
                sorter.SwapEvent += SwapIvent;
                setSpeedEvente += sorter.SetSpeed;
            }

        }
        void LoadSorters()
        {
            sortersList = LoadMethods();
            AddSorterssIvents();

        }
        public string[] GetNamesMethods()
        {
            LoadSorters();
            string[] buff;
            buff = new string[sortersList.Count];
            for (int i = 0; i < sortersList.Count; i++)
            {
                buff[i] = sortersList[i].Show();
            }
            return buff;
        }
        
        public void SaveToDB()
        {           
            SaveToDB(array, (int)height, (int)lng);
        }
        public void StartInitMethod(int useData)
        {
            switch (useData)
            {
                case 0:
                    //InitFromConsole(array);
                    break;
                case 1:
                    arrayInited = InitFromFile();
                    break;
                case 2:
                    arrayInited = InitFromRandomData();
                    break;
                case 3:
                    arrayInited = InitFromDB();
                    break;
                case 4:
                    arrayInited = InitFromArguments(outArgs);
                    break;

            }
            GetData(ref array, ref height, ref lng);
        }
        
   
        delegate void MessageHandler(string message);
        public void SortFunc(object someObj)
        {
            if (someObj is ISorter obj)
            {
                obj.Sort();
            }
        }
        public int StartSortMethod(int num)
        {
            if (!arrayInited) { return 0; }
            if (num > sortersList.Count) { return 0; }
           
            SortCompleted = false;
            progres = 0;    
            Notify();
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
                    foreach (ISorter sorter in sortersList)
                    {
                        sorter.Init( buff_arr, lng * height );
                        myThreads.Add(new Thread(new ParameterizedThreadStart(SortFunc)));
                    }
                    foreach (var thread in myThreads)
                    {
                        thread.Start(sortersList[count]);
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
                    sortersList[num].Init(buff_arr, lng * height);
                    sortersList[num].Sort();
                    break;
            }

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    array[j, i] = buff_arr[lng * j + i];
                }
            }
            SortCompleted = true;
            return 1;
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
        
        
    }
}
