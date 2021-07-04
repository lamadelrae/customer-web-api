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

        public override Customer Insert(Customer obj)
        {
            obj.IsCustomerValid();
            _baseRepository.Insert(obj);
            return obj;
        }

        public override Customer Update(Customer obj)
        {
            obj.IsCustomerValid();
            _baseRepository.Update(obj);
            return obj;
        }
    }
}
