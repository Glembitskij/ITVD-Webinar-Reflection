using System.Reflection;
using _016_Call_Method;

MyClass myClass = new MyClass();
Console.WriteLine(myClass.MyProperty);
//myClass.SayUserHellow("Alex");

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про метод SayUserHellow 
MethodInfo? sayHellowMethInfo = type.GetMethod("SayUserHellow", 
    BindingFlags.NonPublic 
    | BindingFlags.Instance);

// Виклик інстансового методу SayUserHellow
sayHellowMethInfo?.Invoke(myClass, new object[1] { "Alexs" });
Shade();

// Інформація про метод SayUserHellow 
MethodInfo? getCurrentYearMethInfo = type.GetMethod("GetCurrentYear",
    BindingFlags.NonPublic
    | BindingFlags.Static);

object? currentYear = getCurrentYearMethInfo?.Invoke(null, null);
int? currentYearInt = (int)currentYear;

Console.WriteLine($"Current year - {currentYearInt}");

static void Shade() => Console.WriteLine(new string('-', 10));