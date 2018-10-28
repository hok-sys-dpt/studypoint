using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoints.Models
{
    public class PointListViewModels
    {
        public PointList PointList { get; set; }
        public IEnumerable<PointItem> PointItems { get; set; }
    }
}