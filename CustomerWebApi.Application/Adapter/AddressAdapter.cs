using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Domain.Models;
using CustomerWebApi.Infrastructure.CrossCutting;
using System.Collections.Generic;

namespace CustomerWebApi.Application.Adapter
{
    public class AddressAdapter : IAddressAdapter
    {
        public IEnumerable<Address> DtoListToEntityList(List<AddressDto> dtoList)
        {
            foreach (AddressDto addressDto in dtoList)
                yield return DtoToEntity(addressDto);
        }

        public IEnumerable<AddressDto> EntityListToDtoList(List<Address> entityList)
        {
            foreach (Address address in entityList)
                yield return EntityToDto(address);
        }

        public Address DtoToEntity(AddressDto dto)
        {
            return new Address(dto.Street,
                               dto.District,
                               dto.City,
                               dto.State,
                               new Customer(dto.Customer.Id.GetGuid(), dto.Customer.Name, dto.Customer.Cpf, dto.Customer.BirthDate) { Id = dto.Customer.Id.GetGuid() });
        }

        public AddressDto EntityToDto(Address entity)
        {
            return new AddressDto(entity.Street,
                                  entity.District,
                                  entity.City,
                                  entity.State,
                                  new CustomerDto(entity.Customer.Name, entity.Customer.Cpf, entity.Customer.BirthDate) { Id = entity.Customer.Id.GetGuid() });
        }
    }
}
