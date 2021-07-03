using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.DomainService.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository) : base(repository) { }
    }
}
