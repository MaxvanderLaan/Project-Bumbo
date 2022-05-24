using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Function
    {
        [Key]
        public int FunctionId { get; set; }
        [DisplayName("Functienaam")]
        [Required(ErrorMessage = "Vul alsjeblieft een functienaam in.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vul alsjeblieft een afdeling in.")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
