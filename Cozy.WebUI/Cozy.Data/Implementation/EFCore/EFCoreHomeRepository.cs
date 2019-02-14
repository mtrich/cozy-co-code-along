using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreHomeRepository : IHomeRepository
    {
        public Home Create(Home newHome)
        {
            using (var context = new CozyDbContext())
            {
                context.Homes.Add(newHome);
                context.SaveChanges();

                return newHome; // --> Find out if this is enough to get the
                                // id generated in DB
            }
        }

        public bool DeleteById(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                var homeToBeDeleted = GetById(homeId);
                context.Remove(homeToBeDeleted);
                context.SaveChanges();

                if (GetById(homeId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Home GetById(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Homes.Single(h => h.Id == homeId);
            }
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Homes.Where(h => h.LandLordId == landlordId).ToList();
            }
        }

        public Home Update(Home updatedHome)
        {
            using (var context = new CozyDbContext())
            {
                var existingHome = GetById(updatedHome.Id);
                context.Entry(existingHome).CurrentValues.SetValues(updatedHome);
                context.SaveChanges();

                return existingHome;
            }
        }
    }
}
