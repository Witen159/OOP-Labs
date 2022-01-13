using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.Merge;

namespace BackupsExtra.Save
{
    public class VirtualSave : Save
    {
        public VirtualSave()
        {
            Saver = new Virtual();
            Merge = new VirtualMerge();
            Cleaner = new VirtualCleaner();
        }
    }
}