using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_net_framework
{
    internal class IOLogic
    {
        public void Start()
        {
            ShowMenu();
            //SelectMenuElement(ReadUintNumber());

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
        public void ShowArrayToConsole(int[,] array, int height, int lng)
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

        public void InitFromConsole()
        {
            SetArraySize(out uint lng, out uint height);
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < lng; k++)
                {
                    Console.Write("Enter one arrays element and press enter: ");
                    //array[i, k] = ReadIntNumber();
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
    }
}
