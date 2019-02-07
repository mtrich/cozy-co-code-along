using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    interface IPaymentRepository
    {
        //Read
        Payment GetById(int PaymentId);
        ICollection<Payment> TenantId(string TenantId);
        ICollection<Payment> LeaseId(int LeaseId);

        // Create
        Payment Create(Payment newPayment);

        //Update
        Payment Update(Payment updatedPayment);

        //Delete
        bool DeleteById(int PaymentId);
    }
}
