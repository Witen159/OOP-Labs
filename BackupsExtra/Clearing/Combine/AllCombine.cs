using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Clearing.Combine
{
    public class AllCombine : ICombine
    {
        public List<RestorePoint> CombineCleaning(List<IClearing> clearings, List<RestorePoint> restorePoints)
        {
            List<RestorePoint> pointsToClean = restorePoints;
            foreach (IClearing clearing in clearings)
            {
                pointsToClean = clearing.Clearing(pointsToClean);
            }

            return pointsToClean;
        }
    }
}