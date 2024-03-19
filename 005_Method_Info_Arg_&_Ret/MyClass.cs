namespace _005_Method_Info_Arg___Ret
{
    // <summary>
    /// Створення користувацького класу
    /// </summary>
    internal class MyClass
    {
        public void SayHellow()
        {
            Console.WriteLine("Say Hellow");
        }

        public void SayHellow(string userName)
        {
            Console.WriteLine("Say Hellow");
        }

        private static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}
