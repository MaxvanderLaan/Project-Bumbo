using System.ComponentModel;

namespace Bumbo.Web.Models.Remuneration
{
    public class RemunerationDownloadModel
    {
        [DisplayName("Vergoeding Id")]
        public int RenumerationId { get; set; }
        [DisplayName("Werknemer Id")]
        public int EmployeeId { get; set; }
        [DisplayName("Datum")]
        public string Date { get; set; }
        [DisplayName("Gewerkte minuten")]
        public double Hours { get; set; }
        [DisplayName("Toeslag")]
        public double SurtaxRate { get; set; }
        [DisplayName("Goedgekeurd")]
        public string IsApproved { get; set; }
    }
}