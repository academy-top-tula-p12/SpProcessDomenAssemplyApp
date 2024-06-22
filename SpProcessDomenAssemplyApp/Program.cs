using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

Console.WriteLine(" -----   BEFORE   ------");
foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
    Console.WriteLine(ass.GetName().Name);
Console.WriteLine();

AssPower(10.5, 6);

GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine(" -----   AFTER   ------");
foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
    Console.WriteLine(ass.GetName().Name);
Console.WriteLine();

void AssPower(double x, int n)
{
    AssemblyLoadContext context = new AssemblyLoadContext("Power", true);
    context.Unloading += Context_Unloading;

    var assPath = Path.Combine(Directory.GetCurrentDirectory(), "UnitLib.dll");
    Assembly assembly = context.LoadFromAssemblyPath(assPath);

    var type = assembly.GetType("UnitLib.Opers");
    if (type is not null)
    {
        var powerMethod = type.GetMethod("Power", BindingFlags.Static | BindingFlags.Public);
        var result = powerMethod?.Invoke(null, new object[] { x, n });

        if(result != null)
            Console.WriteLine(result);
    }

    Console.WriteLine(" -----   LOAD   ------");
    foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
        Console.WriteLine(ass.GetName().Name);
    Console.WriteLine();


    // UNLOAD
    context.Unload();

}

void Context_Unloading(AssemblyLoadContext context)
{
    Console.WriteLine($"Assembly {context.Name} upload");
}


