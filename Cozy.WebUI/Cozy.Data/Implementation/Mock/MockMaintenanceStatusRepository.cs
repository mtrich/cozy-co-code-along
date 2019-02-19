using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    class MockMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        private List<MaintenanceStatus> MaintenanceStatuses = new List<MaintenanceStatus>()
        {

        };

        public MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus)
        {
            newMaintenanceStatus.Id = MaintenanceStatuses.OrderByDescending(m => m.Id).Single().Id + 1;
            MaintenanceStatuses.Add(newMaintenanceStatus);

            return newMaintenanceStatus;
        }

        public bool DeleteById(int maintenanceStatusId)
        {
            var maintenanceStatus = GetById(maintenanceStatusId);
            MaintenanceStatuses.Remove(maintenanceStatus);
            return true;
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            return MaintenanceStatuses.Single(m => m.Id == maintenanceStatusId);
        }

        public MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus)
        {
            DeleteById(updatedMaintenanceStatus.Id);
            MaintenanceStatuses.Add(updatedMaintenanceStatus);

            return updatedMaintenanceStatus;
        }
    }
}
