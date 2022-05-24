using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Contract
    {

        [Key] public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int FunctionId { get; set; }

        [ForeignKey("FunctionId")]
        public Function Function { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[1-9]{1}$", ErrorMessage = "Moet een getal zijn tussen de 1-9")]
        public int Scale { get; set; }

        [Required(ErrorMessage = "Contract moet een begin datum hebben")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[0-4]{1}[0-9]{0,1}$", ErrorMessage = "Moet een cijfer onder de 50 zijn")]
        public int? MinimalHours { get; set; }
        
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}