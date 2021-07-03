using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerWebApi.Application.Services
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressService _addressService;
        private readonly IAddressAdapter _addressAdapter;
        private readonly ICustomerService _customerService;

        public AddressApplicationService(IAddressService addressService,
                                         ICustomerService customerService,
                                         IAddressAdapter addressAdapter)
        {
            _addressService = addressService;
            _customerService = customerService;
            _addressAdapter = addressAdapter;
        }

        public AddressDto Add(AddressDto obj)
        {
            Address address = _addressAdapter.DtoToEntity(obj);
            address.SetCustomer(_customerService.Get(obj.Customer.Id));
            return _addressAdapter.EntityToDto(_addressService.Insert(address));
        }

        public void Delete(Guid id)
        {
            _addressService.Delete(_addressService.Get(id));
        }

        public IEnumerable<AddressDto> Get()
        {
            return _addressAdapter.EntityListToDtoList(_addressService.Get().ToList());
        }

        public AddressDto Get(Guid id)
        {
            return _addressAdapter.EntityToDto(_addressService.Get(id));
        }

        public AddressDto Update(AddressDto obj)
        {
            Address address = _addressAdapter.DtoToEntity(obj);
            return _addressAdapter.EntityToDto(_addressService.Update(address));
        }
    }
}
