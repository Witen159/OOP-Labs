namespace Backups.Interfaces
{
    public interface ISaveLocal
    {
        public abstract void Save(string backupPath, string restorePointName, int id);
    }
}