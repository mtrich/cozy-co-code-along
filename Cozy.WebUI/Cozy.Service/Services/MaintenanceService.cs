using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IMaintenanceService
    {
        Maintenance GetById(int maintenanceId);
    }

    //class MaintenanceService : IMaintenanceService
    //{

    //    //public MaintenanceService(IMaintenanceRepository )
    //    //{

    //    //}

    //    //public Maintenance GetById(int maintenanceId)
    //    //{

    //    //}
    //}
}
