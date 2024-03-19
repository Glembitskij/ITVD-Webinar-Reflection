namespace _011_Attributes_Info
{
    [Obsolete("Create new class")]
    [MyAttributes("MyClassAttributes", Age = 20)]
    public class MyClass
    {
        [Obsolete("Create new method")]
        [MyAttributes("MyMethodAttributes", Age = 30)]
        public void Method() {}
    }
}
