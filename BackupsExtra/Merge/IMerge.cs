using Backups.Entities;
using Backups.Interfaces;

namespace BackupsExtra.Merge
{
    public interface IMerge
    {
        void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint, IMethod method);
    }
}