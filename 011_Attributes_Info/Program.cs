using _011_Attributes_Info;

MyClass myClass = new MyClass();

// Створення екземпляра класу Type
Type type = myClass.GetType();

// Інформація про всі атрибути
object[] attributes = type.GetCustomAttributes(false);

// Перебираємо всі атрибути
foreach (object attribute in attributes)
{
    Console.WriteLine($"{attribute.GetType()}");

    if (attribute is MyAttributes) {

        // downCast to MyAttributes
        MyAttributes? my = attribute as MyAttributes;
        my?.ShowInfo();
    }

    if (attribute is ObsoleteAttribute) {

        // downCast to ObsoleteAttribute
        ObsoleteAttribute? obsolete = attribute as ObsoleteAttribute;
        Console.WriteLine(obsolete?.IsDefaultAttribute());
    }
    Shade();
}

static void Shade() => Console.WriteLine(new string('-', 10));