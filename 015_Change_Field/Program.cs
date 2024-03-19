using _015_Change_Field;
using System.Reflection;

// Створення екземпляру користувацького типу
MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про поле _myInstanceField
FieldInfo? instanceFieInf = type.GetField("_myInstanceField", 
    BindingFlags.NonPublic 
    | BindingFlags.Instance);
Console.WriteLine($"old value of field - {instanceFieInf?.GetValue(myClass)}");

// Змінюємо значення поля _myInstanceField
instanceFieInf?.SetValue(myClass, 40);
Console.WriteLine($"new value of field - {instanceFieInf?.GetValue(myClass)}");

Shade();

// Інформація про поле _myStaticField
FieldInfo? staticFieInf = type.GetField("_myStaticField", 
    BindingFlags.NonPublic 
    | BindingFlags.Static);
Console.WriteLine($"old value of field - {staticFieInf?.GetValue(null)}");

// Змінюємо значення поля _myStaticField
staticFieInf?.SetValue(null, 80);
Console.WriteLine($"new value of field - {staticFieInf?.GetValue(null)}");
static void Shade() => Console.WriteLine(new string('-', 10));