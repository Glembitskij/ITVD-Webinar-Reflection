namespace _004_Method_Info
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

        private string SayUserHellow(string userName)
        {
            return $"Hellow {userName}";
        } 

        private static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}
