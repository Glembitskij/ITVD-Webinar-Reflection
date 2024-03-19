using _005_Method_Info_Arg___Ret;
using System.Reflection;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Отримання інформації про метод (вказуємо кількіть аргументів)
MethodInfo? sayHellowMethInfoWithoutArg = 
    type.GetMethod("SayHellow", BindingFlags.Public | BindingFlags.Instance, new Type[1] { typeof(string)});

// Виводемо ім'я методу
Console.WriteLine($"{sayHellowMethInfoWithoutArg?.Name}");

// Отримуємо повертайме значення методу
Type? returnType = sayHellowMethInfoWithoutArg?.ReturnType;
Console.WriteLine(returnType?.Name);

// Отримання інформації про аргументи метода
ParameterInfo[]? parameterInfos = sayHellowMethInfoWithoutArg?.GetParameters();

// Перебираємо інформацію про аргументи метода
for (int i = 0; i < parameterInfos?.Length; i++)
{
    ParameterInfo parameterInfo = parameterInfos[i];
    Console.WriteLine($"Ім'я аргументу - {parameterInfo.Name} " +
        $"- тип {parameterInfo.ParameterType} " +
        $"- дефолтне значення {parameterInfo.DefaultValue}");
}