using _008_Constructors_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

ConstructorInfo[] constructorInfos = type.GetConstructors(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Static
    | BindingFlags.Instance);

foreach (ConstructorInfo constructorInfo in constructorInfos)
{
    Console.WriteLine($"Ім'я конструктора - {constructorInfo.Name} " +
        $"статийний - {constructorInfo.IsStatic} " +
        $"публічний - {constructorInfo.IsPublic}");

    ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

    foreach (ParameterInfo parameterInfo in parameterInfos)
    {
        Console.WriteLine($"{parameterInfo.Name} - {parameterInfo.ParameterType}");
    }

    Shade();
}

static void Shade() => Console.WriteLine(new string('-', 10));