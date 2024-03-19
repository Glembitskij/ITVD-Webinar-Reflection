/// <summary>
/// Створення користувацького класу
/// </summary>
/// 
namespace _007_Event_Info
{
    internal class Employee
    {
        private Action? _payEvent;

        public event Action PayEvent
        {
            add { _payEvent += value; } 
            remove { _payEvent -= value; }
        }
        public int GetSalary(int hour, int payForHour)
        {
            int result = hour * payForHour;
            _payEvent?.Invoke();
            return result;
        }
    }
}
