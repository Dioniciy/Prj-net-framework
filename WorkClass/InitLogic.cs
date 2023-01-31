using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WorkClassNS
{
    public class InitLogic
    {
        int height;
        int lng;
        bool arrayInited;
        ServerLogic server = new ServerLogic();
        int[,] array = new int[1000,1000] ;
        
        public InitLogic( )
        {
     
        }
        FileLogic myFile = new FileLogic();
        Random rnd = new Random();
        public void GetData(ref int[,]buff, ref int _height, ref int _lng)
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    buff[i, k] =  array[i, k];
                }
            }
            _height = height;
            _lng = lng;
        }
        public bool InitFromArguments(string[] outArgs)
        {
            if (outArgs == null) { return false;  }
            if (int.TryParse(outArgs[0], out lng) == false)
            {
                //log.Info("Invalid data for lengh!");
                lng = 10;
            }
            if (int.TryParse(outArgs[1], out height) == false)
            {
                //log.Info("Invalid data for height!");
                height = 10;
            }

           // workClass.SetSize(height, lng);
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    if (int.TryParse(outArgs[lng * i + k + 2], out array[i, k]) == false)
                    {
                        //log.Info("Invalid data for element!");
                        array[i, k] = 0;
                    }
                }
            }
            return true;
        }

       
        public bool InitFromFile()
        {

            string[] buff = myFile.ReadFile();
            if (buff != null)
            {

            }
            if (int.TryParse(buff[0], out lng) == false)
            {
                arrayInited = false;

                //log.Info("Can`t convert string from file to int!");
                return false;
            }
            if (int.TryParse(buff[1], out height) == false)
            {
                arrayInited = false;
                //log.Info("Can`t convert string from file to int!");
                return false;
            }
            //workClass.SetSize(height, lng);
            return InitArray(buff, (int)height, (int)lng, 2);

            //arrayInited = true;
        }

        public bool  InitFromRandomData()
        {
            lng = (int)rnd.Next(2, 100);
            height = (int)rnd.Next(2, 20);
            //workClass.SetSize(height, lng);
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    array[i, k] = rnd.Next(1000);
                }
            }
            return true;
        }
        public bool InitArray(string[] data, int __height, int __lng, int shift = 0)
        {
            if (__lng > 1) { lng = __lng; }
            else { arrayInited = false; return false; }
            if (__height > 1) { height = __height; }
            else { arrayInited = false; return false; }
           
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < __lng; k++)
                {
                    if (int.TryParse(data[__height * i + k + shift], out array[i, k]) == false)
                    {
                        //log.Info("Invalid data for element!");
                        array[i, k] = 0;
                    }
                }
            }
            
            return true;
        }
        public bool  InitArray(string[,] data, int __height, int __lng)
        {
            if (__lng > 1) { lng = __lng; }
            else { arrayInited = false; return false; }
            if (__height > 1) { height = __height; }
            else { arrayInited = false; return false; }
            //workClass.SetSize(height, lng);
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    if (int.TryParse(data[i, k], out array[i, k]) == false)
                    {
                        //log.Info("Invalid data for element!");
                        array[i, k] = 0;
                    }
                }
            }
           
            return true;
        }

        public bool InitFromDB()
        {
            ArrayTwoDimensional u = server.ReadFromDB();
            if (u != null)
            {
                int cnt = 0;
                if (u.Lng > 1 && u.Height > 1) { lng = u.Lng; height = u.Height; arrayInited = true; }
                else { arrayInited = false; }
                //workClass.SetSize(height, lng);
                for (int i = 0; i < height; i++)
                {
                    for (int k = 0; k < lng; k++)
                    {
                        array[i, k] = GetNumberFromString(u.Data.Substring(cnt), ref cnt);
                    }
                }
                return true;
            }
            return false;
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
               // log.Info($"Can`t convert string {numericString} to int!");
            }
            return number;
        }
    }
}
