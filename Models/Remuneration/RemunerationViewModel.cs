using System.Collections.Generic;

namespace Bumbo.Web.Models.Remuneration
{
    public class RemunerationViewModel
    {
        public List<Domain.Models.Remuneration> Remunerations { get; set; }
        public Domain.Models.Remuneration Model { get; set; }
        public int BranchId { get; set; }
        public string Year { get; set; }
        public string Weeknr { get; set; }
    }
}
