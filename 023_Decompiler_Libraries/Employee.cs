namespace _023_Decompiler_Libraries
{
    public class Employee
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        private int _salary;

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        
        public Employee() { }

        public Employee(string name) {
            Name = name;
        }

        public Employee(string name, int age): this(name) {
            Age = age;
        }

        public Employee(string name, int age, int salary): this(name, age) {
            _salary = salary;
        }

        public void Work()
        {
            Console.WriteLine("Do some work!");
        }
    }
}
