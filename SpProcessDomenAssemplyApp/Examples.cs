using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpProcessDomenAssemplyApp
{
    public class Examples
    {
        public static void ProcessExample()
        {
            //Process process = Process.GetCurrentProcess();
            //Console.WriteLine($"Handle: {process.Handle}");
            //Console.WriteLine($"Id: {process.Id}");
            //Console.WriteLine($"Priority: {process.BasePriority}");
            //Console.WriteLine($"Main Window Title: {process.MainWindowTitle}");
            //Console.WriteLine($"Name: {process.ProcessName}");
            //Console.WriteLine($"Start Time: {process.StartTime}");
            //Console.WriteLine($"Threads: {process.Threads.Count}");
            //Console.WriteLine($"Priority: {process.BasePriority}");
            //Console.WriteLine($"Memory Size: {process.VirtualMemorySize64}");


            //ProcessStartInfo startInfo = new();
            //startInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            //startInfo.Arguments = "https://yandex.ru";

            //startInfo.FileName = @"calc.exe";
            //startInfo.Arguments = @"D:\num.txt";

            //var proc = Process.Start(startInfo);

            //var key = Console.ReadKey(true);

            //proc.Kill();

            //key = Console.ReadKey(true);
        }

        public static void DomainAssamblyExample()
        {
            AppDomain domen = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domen.FriendlyName}");
            Console.WriteLine($"Directory: {domen.BaseDirectory}");

            foreach (Assembly a in domen.GetAssemblies())
                Console.WriteLine(a.GetName().Name);

            Assembly lib = Assembly.LoadFrom("UnitLib.dll");

            Console.WriteLine(lib.GetName().Name);
            Console.WriteLine(lib.FullName);

            Type[] types = lib.GetTypes();
            foreach (Type t in types)
                Console.WriteLine(t.Name);
        }
    }
}
