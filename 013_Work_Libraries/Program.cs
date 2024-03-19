using System.Reflection;

Assembly assembly = Assembly.Load("014_ClassLibrary");

Type[] typesAssembly = assembly.GetTypes();

foreach (Type type in typesAssembly)
{
    Console.WriteLine(type.Name);
}