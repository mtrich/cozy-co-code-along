using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface IPaymentRepository
    {
        //Read
        Payment GetById(int paymentId);
        ICollection<Payment> GetByTenantId(string tenantId);
        ICollection<Payment> GetByLeaseId(int leaseId);

        // Create
        Payment Create(Payment newPayment);

        //Update
        Payment Update(Payment updatedPayment);

        //Delete
        bool DeleteById(int paymentId);
    }
}
