using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Clearing.Combine
{
    public class AllCombine : ICombine
    {
        public List<RestorePoint> CombineCleaning(List<IClearing> clearings, List<RestorePoint> restorePoints)
        {
            foreach (IClearing clearing in clearings)
            {
                restorePoints = clearing.Clearing(restorePoints);
            }

            return restorePoints;
        }
    }
}