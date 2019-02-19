using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface IMaintenanceRepository
    {
        //Read
        Maintenance GetById(int maintenanceId);
        ICollection<Maintenance> GetByHomeId(int homeId);
        ICollection<Maintenance> GetByTenantId(string tenantId);

        // Create
        Maintenance Create(Maintenance newMaintenance);

        //Update
        Maintenance Update(Maintenance updatedMaintenance);

        //Delete
        bool DeleteById(int maintenanceId);
    }
}
