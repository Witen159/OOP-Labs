using Backups.Entities;

namespace BackupsExtra.Recovery
{
    public interface IRecovery
    {
        void Recovery(RestorePoint restorePoint);
    }
}