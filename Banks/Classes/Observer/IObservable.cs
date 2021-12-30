using Banks.Classes.Observer.Notification;

namespace Banks.Classes.Observer
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(INotification notification);
    }
}