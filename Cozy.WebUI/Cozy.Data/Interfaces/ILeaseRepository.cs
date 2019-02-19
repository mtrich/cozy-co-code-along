using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface ILeaseRepository
    {
        //Read
        Lease GetById(int leaseId);
        ICollection<Lease> GetByTenantId(string tenantId);
        ICollection<Lease> GetByHomeId(int homeId);

        //Create
        Lease Create(Lease newLease);

        //Update
        Lease Update(Lease updatedLease);

        //Delete
        bool DeleteById(int leaseId);
    }
}
