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
        
        int[,] array;
        public InitLogic(ref int[,] buff, ref int length, ref int _height)
        {
            array = buff;
            lng = length;
            height = _height;
            
        }
        FileLogic myFile = new FileLogic();
        Random rnd = new Random();
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

            return InitArray(buff, (int)height, (int)lng, 2);

            //arrayInited = true;
        }

        public bool  InitFromRandomData(int[,] array)
        {
            lng = (int)rnd.Next(2, 100);
            height = (int)rnd.Next(2, 20);

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
    }
}
