namespace BackupsExtra.Logger
{
    public interface ILogger
    {
        void CreateLog(string message, bool activeTimeCode);
    }
}