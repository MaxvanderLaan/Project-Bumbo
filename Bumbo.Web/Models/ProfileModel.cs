using System.Collections.Generic;
using Bumbo.Domain.Models;

namespace Bumbo.Web.Models
{
    public class ProfileModel
    {
        public Domain.Models.Employee Employee { get; set; }
        public List<ProfileColleague> Colleagues { get; set; }
    }
}
