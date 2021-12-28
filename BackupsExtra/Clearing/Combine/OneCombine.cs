using System.Collections.Generic;
using System.Linq;
using Backups.Entities;

namespace BackupsExtra.Clearing.Combine
{
    public class OneCombine : ICombine
    {
        public List<RestorePoint> CombineCleaning(List<IClearing> clearings, List<RestorePoint> restorePoints)
        {
            var pointsToClean = new List<RestorePoint>();
            foreach (IClearing clearing in clearings)
            {
                List<RestorePoint> tempPoints = clearing.Clearing(restorePoints);
                foreach (RestorePoint tempPoint in tempPoints.Where(tempPoint => !pointsToClean.Contains(tempPoint)))
                {
                    pointsToClean.Add(tempPoint);
                }
            }

            return pointsToClean;
        }
    }
}