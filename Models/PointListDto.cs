using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoints.Models
{
    public class PointListDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int PointItemId { get; set; }

        public string PointItemName { get; set; }

        public int Points { get; set; }

        public string Remark { get; set; }

        public string DateAdded { get; set; }
    }
}