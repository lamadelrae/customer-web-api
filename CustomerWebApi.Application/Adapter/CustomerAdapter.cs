using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Domain.Models;
using CustomerWebApi.Infrastructure.CrossCutting;
using System.Collections.Generic;

namespace CustomerWebApi.Application.Adapter
{
    public class CustomerAdapter : ICustomerAdapter
    {
        public IEnumerable<Customer> DtoListToEntityList(List<CustomerDto> dtoList)
        {
            foreach (CustomerDto customerDto in dtoList)
                yield return DtoToEntity(customerDto);
        }

        public IEnumerable<CustomerDto> EntityListToDtoList(List<Customer> entityList)
        {
            foreach (Customer customer in entityList)
                yield return EntityToDto(customer);
        }

        public Customer DtoToEntity(CustomerDto dto)
        {
            Customer customer = new Customer(dto.Name, dto.Cpf, dto.BirthDate) { Id = dto.Id.GetGuid() };
            foreach (AddressDto addressDto in dto.Addresses)
                customer.Addresses.Add(new AddressAdapter().DtoToEntity(addressDto));

            return customer;
        }

        public CustomerDto EntityToDto(Customer entity)
        {
            CustomerDto customer = new CustomerDto
            {
                Id = entity.Id.GetGuid(),
                Name = entity.Name,
                Cpf = entity.Cpf,
                BirthDate = entity.BirthDate
            };

            foreach (Address address in entity.Addresses)
                customer.Addresses.Add(new AddressAdapter().EntityToDto(address));

            return customer;
        }
    }
}
