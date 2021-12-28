using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Clearing.Combine
{
    public interface ICombine
    {
        List<RestorePoint> CombineCleaning(List<IClearing> clearings, List<RestorePoint> restorePoints);
    }
}