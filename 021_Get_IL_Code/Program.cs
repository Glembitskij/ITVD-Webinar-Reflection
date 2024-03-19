using _021_Get_IL_Code;
using Mono.Cecil;
using System.Reflection;
using Mono.Cecil.Cil;
using MethodBody = Mono.Cecil.Cil.MethodBody;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

string assemblyPath = Assembly.GetExecutingAssembly().Location;

// Завантажуємо збірку за допомогою Mono.Cecil
AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath);

MethodDefinition method = assembly.MainModule.Types
         .SelectMany(t => t.Methods)
         .FirstOrDefault(m => m.Name == "Test");

string code = ConvertMethodToCSharp(method);
Console.WriteLine(code);

static string ConvertMethodToCSharp(MethodDefinition method)
{
    // Створюємо StringBuilder для зберігання коду C#
    var sb = new System.Text.StringBuilder();

    // Додаємо заголовок методу
    sb.AppendLine($"static void {method.Name}()");
    sb.AppendLine("{");

    // Отримуємо тіло методу
    MethodBody body = method.Body;
    
    // Проходимося по всіх IL-інструкціях методу
    foreach (Instruction instruction in body.Instructions)
    {
        // Додаємо текст IL-інструкції у вигляді коментаря
        sb.AppendLine($"    // {instruction}");
    }

    // Закриваємо метод
    sb.AppendLine("}");

    // Повертаємо згенерований код C#
    return sb.ToString();
}