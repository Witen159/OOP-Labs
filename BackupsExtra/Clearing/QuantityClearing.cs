using System;
using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Clearing
{
    public class QuantityClearing : IClearing
    {
        private const int MinQuantity = 1;
        public QuantityClearing(int quantity)
        {
            if (quantity < MinQuantity)
                throw new Exception($"Quantity of Restore Points should be at least {MinQuantity}");
            Quantity = quantity;
        }

        public int Quantity { get; }
        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            var pointsToClean = new List<RestorePoint>();
            for (int i = 0; i < restorePoints.Count - Quantity; i++)
                pointsToClean.Add(restorePoints[i]);
            return pointsToClean;
        }
    }
}