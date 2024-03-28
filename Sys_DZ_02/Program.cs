using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys_DZ_02
{
    //Написать класс Worker и несколько классов-наследников (напр, Manager, Director, Programmer),
    //определить в них методы и атрибуты. Данные классы скомпилировать в отдельный dll-файл.
    //Далее написать программу, в которой данный dll загружается и создать несколько работников и вызвать их методы.
    internal class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(@"Workers.dll");
            Assembly assembly = Assembly.Load(assemblyName);

            Module module = assembly.GetModule("Workers.dll");

            Type Worker = module.GetType("Workers.Worker");
            Type Manager = module.GetType("Workers.Manager");
            Type Programmer = module.GetType("Workers.Programmer");

            ConstructorInfo workerConstructor = Worker.GetConstructor(new Type[] { typeof(string) });
            ConstructorInfo managerConstructor = Manager.GetConstructor(new Type[] { typeof(string) });
            ConstructorInfo programmerConstructor = Programmer.GetConstructor(new Type[] { typeof(string) });

            dynamic w = workerConstructor.Invoke(new object[] { "Ivan" });
            w.work();
            dynamic m = managerConstructor.Invoke(new object[] { "Petya" });
            m.work();
            dynamic p = programmerConstructor.Invoke(new object[] { "Denis" });
            p.work();

            Console.WriteLine(w.name);
            Console.WriteLine(m.name);
            Console.WriteLine(p.name);

            Console.ReadKey();
        }
    }
}
