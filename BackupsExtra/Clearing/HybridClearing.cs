using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Entities;
using BackupsExtra.Clearing.Combine;
using BackupsExtra.Tools;

namespace BackupsExtra.Clearing
{
    public class HybridClearing : IClearing
    {
        private List<IClearing> _clearingMethods;
        private ICombine _combineType;
        public HybridClearing(List<IClearing> clearings, ICombine combine)
        {
            _clearingMethods = clearings;
            _combineType = combine;
        }

        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            return _combineType.CombineCleaning(_clearingMethods, restorePoints);
        }
    }
}