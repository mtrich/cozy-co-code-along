using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    class EFCoreTenantRepository : ITenantRepository
    {
        public Tenant Create(Tenant newTenant)
        {
            using (var context = new CozyDbContext())
            {
                context.Tenants.Add(newTenant);
                context.SaveChanges();

                return newTenant;
            }
        }

        public bool DeleteById(string tenantId)
        {
            using (var context = new CozyDbContext())
            {
                var tenantToBeDeleted = GetById(tenantId);
                context.Remove(tenantToBeDeleted);
                context.SaveChanges();

                if (GetById(tenantId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Tenant GetById(string tenantId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Tenants.Single(t => t.Id == tenantId);
            }
        }

        public Tenant Update(Tenant updatedTenant)
        {
            using (var context = new CozyDbContext())
            {
                var existingTenant = GetById(updatedTenant.Id);
                context.Entry(existingTenant).CurrentValues.SetValues(updatedTenant);
                context.SaveChanges();

                return existingTenant;
            }
        }
    }
}
