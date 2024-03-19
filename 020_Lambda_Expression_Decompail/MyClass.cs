namespace _020_Lambda_Expression_Decompail
{
    internal class MyClass
    {
        private sealed class NestedClass
        {
            public static readonly NestedClass nested = new NestedClass();

            public static Action<string> action;

            internal void NestedMethod(string name)
            {
                Console.WriteLine(name);
            }
        }

        public void Method(string name)
        {
            Action<string> action = NestedClass.action ?? 
                (NestedClass.action = new Action<string>(NestedClass.nested.NestedMethod));

            action.Invoke(name);
        }
    }

}

