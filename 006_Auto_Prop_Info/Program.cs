// (Auto-implemented Property) - це спосіб оголошення властивостей в класі,
// який спрощує синтаксис та забезпечує швидкий доступ до приватних полів класу.

// Під "капотом" створюєтся приватне поле для зберігання значення властивості
// та  два публічних методи доступу для отримання та встановлення значення
// цієї властивості.

using _006_Auto_Prop_Info;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про властивості классу MyClass
PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static);

Shade("Property info");

// Перебираємо кожну властивість та виводимо інформацію про неї
foreach (PropertyInfo propertyInfo in propertyInfos)
{
    Console.WriteLine($"Ім'я властивості {propertyInfo.Name} - тип {propertyInfo.PropertyType} " +
        $"- значеня поля {propertyInfo.GetValue(myClass)} " +
        $"- чи можна прочитати {propertyInfo.CanRead}" +
        $"- чи можна записати {propertyInfo.CanWrite}");
}

// Інформація про поля классу MyClass
FieldInfo[] fieldInfos = type.GetFields(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static);

Shade("Field info");

// Перебираємо кожне поля та виводимо інформацію про нього
foreach (FieldInfo fieldInfo in fieldInfos)
{
    Console.WriteLine($"Ім'я поля {fieldInfo.Name} - тип {fieldInfo.FieldType} " +
        $"- значеня поля {fieldInfo.GetValue(myClass)}");
}

// Інформація про методи классу MyClass
MethodInfo[] methodInfos = type.GetMethods(
    BindingFlags.Public
    | BindingFlags.NonPublic
    | BindingFlags.Instance
    | BindingFlags.Static
    | BindingFlags.DeclaredOnly);

Shade("Method info");

// Перебираємо кожний метод та виводимо інформацію про нього
foreach (MethodInfo methodInfo in methodInfos)
{
    Console.WriteLine($"Ім'я метода - {methodInfo.Name} " +
        $"- чи метод приватний {methodInfo.IsPrivate} " +
        $"- чи метод публічний {methodInfo.IsPublic} " +
        $"- чи метод є статичний {methodInfo.IsStatic}");
}

static void Shade(string title) => 
    Console.WriteLine(string.Concat(new string('-', 5), $"{title}", new string('-', 5)));