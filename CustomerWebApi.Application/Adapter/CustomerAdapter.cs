using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Domain.Models;
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
            Customer customer = new Customer(dto.Name, dto.Cpf, dto.BirthDate);
            foreach (AddressDto addressDto in dto.Addresses)
                customer.Addresses.Add(new Address(customer.Id, addressDto.Street, addressDto.District, addressDto.City, addressDto.State));

            return customer;
        }

        public CustomerDto EntityToDto(Customer entity)
        {
            CustomerDto customer = new CustomerDto(entity.Name, entity.Cpf, entity.BirthDate);
            foreach (Address address in entity.Addresses)
                customer.Addresses.Add(new AddressDto(address.Street, address.District, address.City, address.State, customer.Id));

            return customer;
        }
    }
}
