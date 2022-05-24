using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Standard
    {
        [Key]
        public int StandardId { get; set; }
        [Required(ErrorMessage = "Vul alsjeblieft een activiteit in.")]
        [DisplayName("Activiteit")]
        public Activity Activity { get; set; }
        [Required(ErrorMessage = "Vul alsjeblieft een normering in.")]
        public int Norm { get; set; }
        [Required(ErrorMessage = "Vul alsjeblieft een beschrijving in.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Selecteer alsjeblieft de bijbehorende branch bij de normering.")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }

    public enum Activity
    {
        Coli,
        Restock,
        Cashout,
        Fresh,
        Mirror
    }
}
