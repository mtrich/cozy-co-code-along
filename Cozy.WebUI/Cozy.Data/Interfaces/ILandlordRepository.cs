﻿using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface ILandlordRepository
    {
        //Read
        Landlord GetById(int LandlordId);

        // Create
        Landlord Create(Landlord newLandlord);

        //Update
        Landlord Update(Landlord updatedLandlord);

        //Delete
        bool DeleteById(int LandlordId);
    }
}
