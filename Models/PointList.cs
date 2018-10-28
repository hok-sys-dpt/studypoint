using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyPoints.Models
{
    public class PointList
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public int PointItemId { get; set; }

        [Required]
        [Display(Name = "ポイント項目")]
        public string PointItemName { get; set; }

        [Range(0, 1000)]
        [Display(Name = "ポイント数")]
        public int Points { get; set; }

        [MaxLength(255)]
        [Display(Name = "備考")]
        public string Remark { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateAdded { get; set; }
    }
}