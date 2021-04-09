using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FagElGamous.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FagElGamousUser class
    public class FagElGamousUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string UserFirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string UserLastName { get; set; }

        //We can add more fields like university or group here
    }
}
