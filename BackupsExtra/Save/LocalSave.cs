using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.Merge;

namespace BackupsExtra.Save
{
    public class LocalSave : Save
    {
        public LocalSave()
        {
            Saver = new Local();
            Merge = new LocalMerge();
            Cleaner = new LocalCleaner();
        }
    }
}