using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface IMaintenanceStatusRepository
    {
        //Read
        MaintenanceStatus GetById(int MaintenanceStatusId);

        // Create
        MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus);

        //Update
        MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus);

        //Delete
        bool DeleteById(int MaintenanceStatusId);
    }
}
