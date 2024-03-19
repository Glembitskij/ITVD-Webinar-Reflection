namespace _014_ClassLibrary
{
    public class Employee : IEmployee
    {
        public void DoWork()
        {
            Console.WriteLine("Write code");
        }

        public int GetSalary()
        {
            Random random = new Random();
            return random.Next(100, 1000);
        }
    }
}
