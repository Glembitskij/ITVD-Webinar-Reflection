using _007_Event_Info;
using System.Reflection;

Employee employee = new Employee();
employee.PayEvent += () => { Console.WriteLine("Радість від отримання зарплатні!:)"); };

// Створення екземпляра класу Type
Type type = employee.GetType();

EventInfo[] eventInfos = type.GetEvents(
    BindingFlags.Public
    | BindingFlags.Instance);

foreach (EventInfo eventInfo in eventInfos)
{
    Console.WriteLine($"Ім'я події - {eventInfo.Name} " +
        $"тип події - {eventInfo.EventHandlerType} " +
        $"чиє мультикаст делегат - {eventInfo.IsMulticast}");
}

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
        $"- значеня поля {fieldInfo.GetValue(employee)}");
}