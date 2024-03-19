// Інформація про поля типу

using _02_FieldInfo;
using System.Reflection;

// Створення екземпляру користувацького типу
MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про поля классу MyClass
FieldInfo[] fieldInfos = type.GetFields(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static);

// Перебираємо кожне поля та виводимо інформацію про нього
foreach (FieldInfo fieldInfo in fieldInfos)
{
    Console.WriteLine($"Ім'я поля {fieldInfo.Name} - тип {fieldInfo.FieldType} " +
        $"- значеня поля {fieldInfo.GetValue(myClass)}");
}

Shade();

// Також ми можемо отримати інформацію про кожне конкретне поле

FieldInfo? mystringInfo = type.GetField("mystring", BindingFlags.NonPublic | BindingFlags.Instance);
GetInfoField(mystringInfo, myClass);
Shade();

FieldInfo? myintInfo = type.GetField("myint", BindingFlags.Public | BindingFlags.Instance);
GetInfoField(myintInfo, myClass);
Shade();

FieldInfo? myboolInfo = type.GetField("mybool", BindingFlags.NonPublic | BindingFlags.Static);
GetInfoField(myboolInfo, myClass);
Shade();

static void GetInfoField(FieldInfo? fieldInfo, MyClass myClass) => 
    Console.WriteLine($"Ім'я поля {fieldInfo?.Name} - тип {fieldInfo?.FieldType} " +
    $"- значеня поля {fieldInfo?.GetValue(myClass)}");

static void Shade() => Console.WriteLine(new string('-', 10));

