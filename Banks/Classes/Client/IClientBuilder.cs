namespace Banks.Classes.Client
{
    public interface IClientBuilder
    {
        void Reset();
        void BuildId(int id);
        void BuildName(string name);
        void BuildSurname(string surname);
        void BuildAddress(string address);
        void BuildPassport(int passportNumber);
        void BuildVerification();
    }
}