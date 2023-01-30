using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkClassNS
{
    internal class FileLogic
    {
        string path = "./input data.txt";
        public string[] ReadFile()
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
                    return null;
                }
            }
            reader = new StreamReader(path);
            line = reader.ReadLine();
            reader.Close();
            string[] buff = line.Split(' ');
            return buff;
            
        }
    }
}
