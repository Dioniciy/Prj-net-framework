using ISorterNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkClassNS
{
    internal class ReflexionLogic
    {
        List<ISorter> sortersL = new List<ISorter>();
        public List<ISorter> LoadMethods()
        {    
            string[] array = Directory.GetFiles("../../../dll", "*.dll");
            //log.Info($"Exist {array.Length} dll files.");
            foreach (string file in array)
            {
                Assembly asm = Assembly.LoadFrom(file);
                foreach (Type type in asm.GetTypes())
                {
                    foreach (Type inteface in type.GetInterfaces())
                    {
                        if (inteface == typeof(ISorter))
                        {
                            sortersL.Add((ISorter)type.InvokeMember(null,
                                                                        BindingFlags.DeclaredOnly |
                                                                        BindingFlags.Public | BindingFlags.NonPublic |
                                                                        BindingFlags.Instance | BindingFlags.CreateInstance,
                                                                        null, null, null));
                            break;
                        }
                    }
                }
            }
            return sortersL;
        }
    }
}
