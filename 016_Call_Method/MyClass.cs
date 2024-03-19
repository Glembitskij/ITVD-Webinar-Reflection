namespace _016_Call_Method
{
    public class MyClass
    {
        public int MyProperty { get => this.GetHashCode(); }

        private void SayUserHellow(string userName)
        {
            Console.WriteLine(MyProperty);
            Console.WriteLine($"Hellow {userName}");
        }

        private static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}
