using Backups.Entities;
using Backups.Interfaces;

namespace BackupsExtra.Merge
{
    public class VirtualMerge : IMerge
    {
        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint, IMethod method)
        {
            if (method is Single)
                return;

            foreach (Repository oldRepository in oldRestorePoint.Repositories)
            {
                bool inBoth = false;
                foreach (Repository newRepository in newRestorePoint.Repositories)
                {
                    if (newRepository.Storages[0].Name == oldRepository.Storages[0].Name)
                    {
                        inBoth = true;
                        break;
                    }
                }

                if (!inBoth)
                    newRestorePoint.AddRepository(oldRepository);
            }
        }
    }
}