using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    public class MockHomeRepository : IHomeRepository
    {
        private List<Home> Homes = new List<Home>()
        {
            new Home { Id = 1, Address = "123 Main Steet Mocked", City = "San Antonio"}
        };

        public Home Create(Home newHome)
        {
            newHome.Id = Homes.OrderByDescending(h => h.Id).Single().Id + 1;
            Homes.Add(newHome);

            return newHome;
        }

        public bool DeleteById(int homeId)
        {
            var home = GetById(homeId);
            Homes.Remove(home);
            return true;
        }

        public Home GetById (int homeId)
        {
            return Homes.Single(h => h.Id == homeId);
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            return Homes.FindAll(h => h.LandLordId == landlordId);
        }

        public Home Update(Home updatedHome)
        {
            DeleteById(updatedHome.Id); // delete the existing home
            Homes.Add(updatedHome);

            return updatedHome;
        }
    }
}
