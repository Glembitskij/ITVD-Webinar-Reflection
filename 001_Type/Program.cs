// Варіанти отримання екземпляру класса Type.

using _001_Type;

class Program
{
    static void Main()
    {
        // Створення екземпляру користувацького типу
        MyClass myClass = new MyClass();

        // 1-й спосіб отримання екземпляра класу Type
        Type typeFirstWay = myClass.GetType();
        
        Console.WriteLine("1-й спосіб: " + typeFirstWay);
        Console.WriteLine("1-й спосіб: " + typeFirstWay.Name);

        Shade();

        // 2-й спосіб отримання екземпляра класу Type
        Type? typeSecondtWay = Type.GetType("_001_Type.MyClass");

        Console.WriteLine("2-й спосіб: " + typeSecondtWay);
        Console.WriteLine("2-й спосіб: " + typeSecondtWay?.Name);

        Shade();

        //3-й спосіб отримання екземпляра класу Type
        Type typeThirdWay = typeof(MyClass);

        Console.WriteLine("3-й спосіб: " + typeThirdWay);
        Console.WriteLine("3-й спосіб: " + typeThirdWay.Name);

        Shade();
    }

    public static void Shade() => Console.WriteLine(new string('-', 10)); 
}