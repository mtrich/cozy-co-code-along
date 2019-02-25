﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class AppUser : IdentityUser
    {
        // Landlord or Tenant
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }

        public ICollection<Home> Homes { get; set; } //Landlord

        public ICollection<Lease> Leases { get; set; } // Tenant
        public ICollection<Maintenance> Maintenances { get; set; } // Tenant
    }
}
