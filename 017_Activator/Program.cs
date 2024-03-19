using _018_Libraries_For_Activators;
using System.Reflection;

MyPublicClass publicClass = new MyPublicClass();
publicClass.Method();

// 'member' is inaccessible due to its protection level
// MyInternalClass internalClass = new MyInternalClass();

// 1. Отримаємо ООП збірки 
//Assembly assembly = Assembly.Load("018_Libraries_For_Activators");
// або
Assembly assembly = Assembly.LoadFrom("C:\\Users\\OLHI\\Desktop\\Курси С#\\ITVDN_Vebinar (Рефлексія в C# поняття)\\ITVD-Webinar-Reflection\\018_Libraries_For_Activators\\bin\\Debug\\net6.0\\018_Libraries_For_Activators.dll");

// 2. Отримаємо інформацію про тип MyInternalClass
Type? type = assembly?.GetType("_018_Libraries_For_Activators.MyInternalClass");

Console.WriteLine($"Імя типу - {type?.Name} " +
    $"- збірка в якій розташовано - {type?.Assembly.GetName()}");

Shade();

// Створюємо єкземпляр классу MyInternalClass
object? instance = Activator.CreateInstance(type);

// Виклик методу Method
MethodInfo? methodInfo = type.GetMethod("Method",
    BindingFlags.Instance
    | BindingFlags.Public);

Console.WriteLine($"{methodInfo?.Name}");
Shade();

// Виклик методу
methodInfo?.Invoke(instance, null);

static void Shade() => Console.WriteLine(new string('-', 10));