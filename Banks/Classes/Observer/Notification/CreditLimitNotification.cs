namespace Banks.Classes.Observer.Notification
{
    public class CreditLimitNotification : INotification
    {
        public string Message(string bankName, double amount)
        {
            return $"Credit limit on on bank {bankName} was changed to {amount}";
        }
    }
}