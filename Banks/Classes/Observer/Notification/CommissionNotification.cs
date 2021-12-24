namespace Banks.Classes.Observer.Notification
{
    public class CommissionNotification : INotification
    {
        public string Message(string bankName, double amount)
        {
            return $"Commission on on bank {bankName} was changed to {amount}";
        }
    }
}