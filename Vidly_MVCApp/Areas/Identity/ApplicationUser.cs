using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DrivingLicence { get; set; }
        public string PhoneNumber { get; set; }

    }
}
