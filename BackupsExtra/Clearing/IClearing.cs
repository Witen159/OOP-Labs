using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Clearing
{
    public interface IClearing
    {
        List<RestorePoint> Clearing(List<RestorePoint> restorePoints);
    }
}