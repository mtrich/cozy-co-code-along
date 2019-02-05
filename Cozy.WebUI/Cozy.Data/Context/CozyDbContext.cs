using Cozy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Context
{
    public class CozyDbContext : DbContext
    {
        public CozyDbContext(DbContextOptions<CozyDbContext> options): base(options)
        {

        }
        // Interprete Models -> db entities
        // query those entities (tables)

        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}
