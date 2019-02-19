﻿using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface ITenantRepository
    {
        //Read
        Tenant GetById(string tenantId);

        // Create
        Tenant Create(Tenant newTenant);

        //Update
        Tenant Update(Tenant updatedTenant);

        //Delete
        bool DeleteById(string tenantId);
    }
}
