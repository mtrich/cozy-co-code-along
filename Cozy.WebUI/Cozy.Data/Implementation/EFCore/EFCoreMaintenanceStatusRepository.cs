using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        public MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus)
        {
            using (var context = new CozyDbContext())
            {
                context.MaintenanceStatuses.Add(newMaintenanceStatus);
                context.SaveChanges();

                return newMaintenanceStatus;
            }
        }

        public bool DeleteById(int maintenanceStatusId)
        {
            using (var context = new CozyDbContext())
            {
                var maintenanceStatusesToBeDeleted = GetById(maintenanceStatusId);
                context.Remove(maintenanceStatusesToBeDeleted);
                context.SaveChanges();

                if (GetById(maintenanceStatusId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            using (var context = new CozyDbContext())
            {
                return context.MaintenanceStatuses.Single(m => m.Id == maintenanceStatusId);
            }
        }

        public MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus)
        {
            using (var context = new CozyDbContext())
            {
                var existingMaintenanceStatus = GetById(updatedMaintenanceStatus.Id);
                context.Entry(existingMaintenanceStatus).CurrentValues.SetValues(updatedMaintenanceStatus);
                context.SaveChanges();

                return existingMaintenanceStatus;
            }
        }
    }
}
