using CustomerWebApi.Domain.Models;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerWebApi.Infrastructure.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public override List<Address> Get()
        {
            return _context.Address.Include(i => i.Customer).ToList();
        }

        public override Address Get(Guid id)
        {
            return _context.Address.Include(i => i.Customer)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}
