namespace Banks.Classes.Observer.Notification
{
    public class PercentNotification : INotification
    {
        public string Message(string bankName, double amount)
        {
            return $"Debit percent on bank {bankName} was changed to {amount}";
        }
    }
}