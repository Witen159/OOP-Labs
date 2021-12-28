using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Entities;

namespace BackupsExtra.Clearing
{
    public class TimeClearing : IClearing
    {
        public TimeClearing(DateTime dateToClean)
        {
            if (dateToClean >= DateTime.Now)
                throw new Exception("Date for cleaning cannot be in the future");
            DateToClean = dateToClean;
        }

        public DateTime DateToClean { get; }
        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            return restorePoints.Where(restorePoint => restorePoint.CreationDate < DateToClean).ToList();
        }
    }
}