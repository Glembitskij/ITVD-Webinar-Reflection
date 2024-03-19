using System.Reflection;

Assembly assembly = Assembly.GetExecutingAssembly();

Type[] types =  assembly.GetTypes();

foreach (Type type in types)
{
    Console.WriteLine(type.Name);

    MethodInfo[] methodInfos = type.GetMethods(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static
    | BindingFlags.DeclaredOnly);

    // Перебираємо кожний метод та виводимо інформацію про нього
    foreach (MethodInfo methodInfo in methodInfos)
    {
        Console.WriteLine($"Ім'я метода - {methodInfo.Name} " +
            $"- чи метод приватний {methodInfo.IsPrivate} " +
            $"- чи метод публічний {methodInfo.IsPublic} " +
            $"- чи метод є статичний {methodInfo.IsStatic}");
    }

    Shade();
}

static void Shade() => Console.WriteLine(new string('-', 10));