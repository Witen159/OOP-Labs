using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Entities;
using BackupsExtra.Clearing.Combine;

namespace BackupsExtra.Clearing
{
    public class HybridClearing : IClearing
    {
        private List<IClearing> _clearingMethods;
        private ICombine _combineType;
        public HybridClearing(List<IClearing> clearings, ICombine combine)
        {
            if (clearings.OfType<HybridClearing>().Any())
            {
                throw new Exception("You cant combine HybridClearing");
            }

            _clearingMethods = clearings;
            _combineType = combine;
        }

        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            return _combineType.CombineCleaning(_clearingMethods, restorePoints);
        }
    }
}