namespace _012_Assembly_Info
{
    // <summary>
    /// Створення користувацького класу
    /// </summary>
    internal class MyClass: Interface1
    {
        public void SayHellow()
        {
            Console.WriteLine("Say Hellow");
        }

        private string SayUserHellow(string userName)
        {
            return $"Hellow {userName}";
        }

        private static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }

        public void Method()
        {
            Console.WriteLine("Method");
        }
    }
}
