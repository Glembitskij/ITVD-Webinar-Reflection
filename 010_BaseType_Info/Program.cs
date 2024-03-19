
using _010_BaseType_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Отримання інформації про базовий тип
Type baseType  = type.BaseType;
Console.WriteLine(baseType.Name);

Shade();

// Інформація про методи базово классу
MethodInfo[] methodInfos = baseType.GetMethods(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static);

// Перебираємо кожний метод та виводимо інформацію про нього
foreach (MethodInfo methodInfo in methodInfos)
{
    Console.WriteLine($"Ім'я метода - {methodInfo.Name} " +
        $"- чи метод приватний {methodInfo.IsPrivate} " +
        $"- чи метод публічний {methodInfo.IsPublic} " +
        $"- чи метод є статичний {methodInfo.IsStatic}");
}

Shade();

// Отримання інформації про базовий тип базового типу:)
Type? baseTypeofbaseType = type?.BaseType?.BaseType;
Console.WriteLine(baseTypeofbaseType?.Name);

Type? interfaceType = type?.GetInterface("Interface1");
Console.WriteLine(interfaceType?.FullName);

static void Shade() => Console.WriteLine(new string('-', 10));