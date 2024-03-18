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

// Перебираємо кожне поля та виводи інформацію про нього
foreach (FieldInfo fieldInfo in fieldInfos)
{
    Console.WriteLine($"Ім'я поля {fieldInfo.Name} - тип {fieldInfo.FieldType} " +
        $"- значеня поля {fieldInfo.GetValue(myClass)}");
}

// Також ми можемо отримати інформацію про кожно крнкретне поля

