using System.Collections.Generic;
using Bumbo.Domain.Models;

namespace Bumbo.Web.Models
{
    public class DashboardModel
    {
        public List<Registration> managerRegistrations { get; set; }
        public List<Availability> managerAvailability { get; set; }
        public List<Registration> medewerkerRegistrations { get; set; }
        public List<Availability> medewerkerAvailability { get; set; }
    }
}
