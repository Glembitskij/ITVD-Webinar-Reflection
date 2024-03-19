namespace _024_Calculator
{
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int a, int b)
        {
            _logger.Log($"Adding {a} and {b}");
            return a + b;
        }
    }
}
