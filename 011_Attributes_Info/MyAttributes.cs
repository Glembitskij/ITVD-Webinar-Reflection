namespace _011_Attributes_Info
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyAttributes: Attribute
    {
        public string _name;
        public int Age { get; set; }

        public MyAttributes(string name)
        {
            _name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_name} - {Age}");
        }
    }
}
