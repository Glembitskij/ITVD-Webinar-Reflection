// Інформація про властивості типу

// Створення екземпляру користувацького типу
using _003_Prop_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про властивості классу MyClass
PropertyInfo[] propertyInfos = type.GetProperties(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static);

// Перебираємо кожну властивість та виводимо інформацію про неї
foreach (PropertyInfo propertyInfo in propertyInfos)
{
    Console.WriteLine($"Ім'я властивості {propertyInfo.Name} - тип {propertyInfo.PropertyType} " +
        $"- значеня поля {propertyInfo.GetValue(myClass)} " +
        $"- чи можна прочитати {propertyInfo.CanRead}" +
        $"- чи можна записати {propertyInfo.CanWrite}");
}
Shade();
// Також ми можемо отримати інформацію про кожну конкретну властивість

PropertyInfo? myIntPropInfo = type.GetProperty("MyIntProp", BindingFlags.Instance | BindingFlags.Public);
GetInfoProp(myIntPropInfo, myClass);
Shade();

PropertyInfo? myStringPropInfo = type.GetProperty("MyStringProp", BindingFlags.Instance | BindingFlags.NonPublic);
GetInfoProp(myStringPropInfo, myClass);
Shade();

PropertyInfo? myBoolPropInfo = type.GetProperty("MyBoolProp", BindingFlags.Static| BindingFlags.NonPublic);
GetInfoProp(myBoolPropInfo, myClass);
Shade();

static void GetInfoProp(PropertyInfo? propertyInfo, MyClass myClass) =>
    Console.WriteLine($"Ім'я властивості {propertyInfo?.Name} - тип {propertyInfo?.PropertyType} " +
    $"- значеня поля {propertyInfo?.GetValue(myClass)}" +
        $"- чи можна прочитати {propertyInfo?.CanRead}" +
        $"- чи можна записати {propertyInfo?.CanWrite}");

static void Shade() => Console.WriteLine(new string('-', 10));