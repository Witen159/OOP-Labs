using Backups.Interfaces;
using BackupsExtra.Cleaner;
using BackupsExtra.Merge;

namespace BackupsExtra.Save
{
    public abstract class Save
    {
        public ISaver Saver { get; protected set; }
        public IMerge Merge { get; protected set; }
        public ICleaner Cleaner { get; protected set; }
    }
}