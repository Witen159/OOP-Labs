using System;

namespace Backups.Entities
{
    public class MyFile
    {
        public MyFile(string name, DateTime creationTime)
        {
            Name = name;
            CreationTime = creationTime;
        }

        public DateTime CreationTime { get; }

        public string Name { get; }
    }
}