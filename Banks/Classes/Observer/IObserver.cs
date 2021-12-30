using Banks.Classes.Observer.Notification;

namespace Banks.Classes.Observer
{
    public interface IObserver
    {
        void Update(INotification notification);
    }
}