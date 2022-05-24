using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class OpeningDay
    {
        [Key]
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int BranchId { get; set; }
        [DisplayName("Openingstijd")]
        [Required(ErrorMessage = "Vul alsjeblieft een openingstijd in.")]
        [Range(typeof(TimeSpan), "06:00", "22:00", ErrorMessage = "De openingstijd moet binnen 06:00 en 22:00 vallen.")]
        public TimeSpan OpenTime { get; set; }
        [DisplayName("Sluitingstijd")]
        [Required(ErrorMessage = "Vul alsjeblieft een sluitingstijd in.")]
        [Range(typeof(TimeSpan), "06:00", "22:00", ErrorMessage = "De sluitingstijd moet binnen 06:00 en 22:00 vallen.")]
        public TimeSpan CloseTime { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}