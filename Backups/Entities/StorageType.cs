namespace Backups.Entities
{
    public enum StorageType
    {
        /// <summary>
        /// Working with file system.
        /// </summary>
        Local,

        /// <summary>
        /// Working with RAM.
        /// </summary>
        Virtual,
    }
}