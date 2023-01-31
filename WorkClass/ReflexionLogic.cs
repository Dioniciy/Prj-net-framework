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
        public void LoadMethods(ref List<ReflectionSorter> sorters)
        {
            sorters.Clear();
            string[] array = Directory.GetFiles("../../../dll", "*.dll");
            //log.Info($"Exist {array.Length} dll files.");
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
    }
}
