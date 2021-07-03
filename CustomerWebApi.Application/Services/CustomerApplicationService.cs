using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerWebApi.Application.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerService _customerService;

        private readonly ICustomerAdapter _customerAdapter;

        public CustomerApplicationService(ICustomerService customerService,
                                          ICustomerAdapter customerAdapter)
        {
            _customerService = customerService;
            _customerAdapter = customerAdapter;
        }

        public CustomerDto Add(CustomerDto obj)
        {
            Customer customer = _customerAdapter.DtoToEntity(obj);
            return _customerAdapter.EntityToDto(_customerService.Insert(customer));
        }

        public void Delete(Guid id)
        {
            _customerService.Delete(_customerService.Get(id));
        }

        public IEnumerable<CustomerDto> Get()
        {
            return _customerAdapter.EntityListToDtoList(_customerService.Get().ToList());
        }

        public CustomerDto Get(Guid id)
        {
            return _customerAdapter.EntityToDto(_customerService.Get(id));
        }

        public CustomerDto Update(CustomerDto obj)
        {
            Customer customer = _customerAdapter.DtoToEntity(obj);
            return _customerAdapter.EntityToDto(_customerService.Update(customer));
        }
    }
}
