using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Forecast
    {
        [Key] public int ForecastId { get; set; }
        [Required]
        public int BranchId { get; set; }
        public int AmountOfCustomers { get; set; }
        public int RollContainers { get; set; }
        public string Description { get; set; }
        public int? AmountOfCashiers { get; set; }
        public int? AmountOfStockClerks { get; set; }
        public int? AmountOfFresh { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}