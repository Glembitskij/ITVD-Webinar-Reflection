namespace _009_Interfaces_Info
{
    internal class MyClass : Interface1, Interface2
    {
        private int _myProperty;
        
        public int MyProperty 
        { 
            get => _myProperty; 
            set => _myProperty = value; 
        }

        public void MethodFirst()
        {
            Console.WriteLine("Method First");
        }

        public void MethodSecond(string argument)
        {
            Console.WriteLine($"Method second, value - {argument}");
        }
    }
}
