using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    class MockTenantRepository : ITenantRepository
    {
        private List<Tenant> Tenants = new List<Tenant>()
        {

        };

        public Tenant Create(Tenant newTenant)
        {
            newTenant.Id = Tenants.OrderByDescending(t => t.Id).Single().Id + 1;
            Tenants.Add(newTenant);

            return newTenant;
        }

        public bool DeleteById(string tenantId)
        {
            var tenant = GetById(tenantId);
            Tenants.Remove(tenant);
            return true;
        }

        public Tenant GetById(string tenantId)
        {
            return Tenants.Single(t => t.Id == tenantId);
        }

        public Tenant Update(Tenant updatedTenant)
        {
            DeleteById(updatedTenant.Id);
            Tenants.Add(updatedTenant);

            return updatedTenant;
        }
    }
}
