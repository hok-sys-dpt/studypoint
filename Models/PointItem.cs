using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyPoints.Models
{
    public class PointItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "ポイント項目")]
        public string Name { get; set; }

        [Range(1,1000)]
        [Display(Name = "ポイント数")]
        public int Points { get; set; }
    }
}