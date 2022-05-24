using System.Collections.Generic;
using System.Security.Claims;
using Bumbo.Domain.Models;

namespace Bumbo.Domain.Services.Dashboard
{
    public interface IDashboard
    {
        void matchUserWithEmployee();
        List<Registration> getManagerRegistrations(ClaimsPrincipal user);
        List<Availability> getManagerAvailability(ClaimsPrincipal user);
        List<Registration> getMedewerkerRegistrations(ClaimsPrincipal user);
        List<Availability> getMedewerkerAvailability(ClaimsPrincipal user);
    }
}
