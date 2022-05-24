using Bumbo.Domain.Models;
using System;

namespace Bumbo.Domain.Services.Registrations
{
    public interface IRegistration
    {
        Registration nfcRegistration(int tagId, DateTime dateTime);
        void checkClocking();
        int SetTagIdWithEmployeeId(int employeeId);
    }
}
