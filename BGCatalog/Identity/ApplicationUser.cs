using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int UserDetailId { get; set; }
    }
}
