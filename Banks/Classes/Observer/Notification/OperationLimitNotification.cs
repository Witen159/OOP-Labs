namespace Banks.Classes.Observer.Notification
{
    public class OperationLimitNotification : INotification
    {
        public string Message(string bankName, double amount)
        {
            return $"Operation Limit on bank {bankName} was changed to {amount}";
        }
    }
}