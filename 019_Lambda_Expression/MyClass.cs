namespace _19_Lambda_Expression
{
    internal class MyClass
    {
        public void Method(string name)
        {
            Action<string> action = (string name) =>
            {
                Console.WriteLine(name);
            };

            action.Invoke(name);
        }
    }
}
