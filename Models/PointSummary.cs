using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoints.Models
{
    public class PointSummary
    {
        public string UserName { get; set; }

        public int TotalPoints { get; set; }

        public int Level { get; set; }

        public int PointsToNextLevel { get; set; }
    }
}