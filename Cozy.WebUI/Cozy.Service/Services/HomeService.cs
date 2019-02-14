﻿using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System.Collections.Generic;

namespace Cozy.Service.Services
{
    public interface IHomeService
    {
        Home GetById(int homeId);
        ICollection<Home> GetByLandlordId(string landlordId);
    }

    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public Home GetById(int homeId)
        {
            return _homeRepository.GetById(homeId);
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            return _homeRepository.GetByLandlordId(landlordId);
        }
    }
}
