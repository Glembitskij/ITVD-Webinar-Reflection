namespace _003_Prop_Info
{
    /// <summary>
    /// Створення користувацького класу
    /// </summary>
    public class MyClass
    {
        public int myint;
        private string mystring = "Hello";
        private static bool mybool = false;

        public int MyIntProp
        {
            get { return myint; }
            set { myint = value; }
        }
        private string MyStringProp
        {
            get { return mystring; }
        }
        private static bool MyBoolProp
        {
            get { return mybool; }
            set { mybool = value; }
        }
    }
}
