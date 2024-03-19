
using _009_Interfaces_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

Type[] interfacesTypes = type.GetInterfaces();

foreach (Type interfacesType in interfacesTypes)
{
    Console.WriteLine($"Ім'я інтерфейсу {interfacesType.Name} " +
        $"чи це класс - {interfacesType.IsClass}");

    MethodInfo[] methodInfos = interfacesType.GetMethods(BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Інформація про методи:");
    Console.ForegroundColor = ConsoleColor.Gray;

    foreach (MethodInfo methodInfo in methodInfos)
    {
        Console.WriteLine($"Ім'я метода - {methodInfo.Name} " +
            $"- чи метод приватний {methodInfo.IsPrivate} " +
            $"- чи метод публічний {methodInfo.IsPublic} " +
            $"- чи метод є статичний {methodInfo.IsStatic}");
    }

    PropertyInfo[] propertyInfos = type.GetProperties(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance);

    if (propertyInfos.Any())
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Інформація про властивості:");
        Console.ForegroundColor = ConsoleColor.Gray;
       
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            Console.WriteLine($"Ім'я властивості {propertyInfo.Name} - тип {propertyInfo.PropertyType} " +
                $"- значеня поля {propertyInfo.GetValue(myClass)} " +
                $"- чи можна прочитати {propertyInfo.CanRead}" +
                $"- чи можна записати {propertyInfo.CanWrite}");
        }
    }

    Shade();
}

static void Shade() => Console.WriteLine(new string('-', 10));