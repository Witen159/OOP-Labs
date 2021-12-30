namespace Banks.Classes.Observer.Notification
{
    public interface INotification
    {
        string Message(string bankName, double amount);
    }
}