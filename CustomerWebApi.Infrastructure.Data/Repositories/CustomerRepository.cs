using CustomerWebApi.Domain.Models;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Infrastructure.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public override List<Customer> Get()
        {
            return _context.Customer.Include(i => i.Addresses).ToList();
        }

        public override Customer Get(Guid id)
        {
            return _context.Customer.Include(i => i.Addresses)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}
