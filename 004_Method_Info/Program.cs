// Інформація про методи типу

using _004_Method_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про методи классу MyClass
MethodInfo[] methodInfos = type.GetMethods(
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
        $"- чи метод є статичний {methodInfo.IsStatic}" );
}
Shade();

// Також ми можемо отримати інформацію про кожний метод 

MethodInfo? sayHellowMethInfo = type.GetMethod("SayHellow", BindingFlags.Public | BindingFlags.Instance);
GetMethodProp(sayHellowMethInfo);
Shade();

MethodInfo? sayUserHellowMethInfo = type.GetMethod("SayUserHellow", BindingFlags.Public | BindingFlags.Instance);
GetMethodProp(sayUserHellowMethInfo);
Shade();

MethodInfo? getCurrentYearMethInfo = type.GetMethod("GetCurrentYear", BindingFlags.Public | BindingFlags.Instance);
GetMethodProp(getCurrentYearMethInfo);
Shade();

static void GetMethodProp(MethodInfo? methodInfo) =>
    Console.WriteLine($"Ім'я метода {methodInfo?.Name}" +
        $"- чи метод приватний {methodInfo?.IsPrivate} " +
        $"- чи метод публічний {methodInfo?.IsPublic} " +
        $"- чи метод є статичний {methodInfo?.IsStatic}");

static void Shade() => Console.WriteLine(new string('-', 10));