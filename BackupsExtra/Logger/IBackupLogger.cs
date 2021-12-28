namespace BackupsExtra.Logger
{
    public interface IBackupLogger
    {
        void CreateLog(string message, bool activeTimeCode);
    }
}