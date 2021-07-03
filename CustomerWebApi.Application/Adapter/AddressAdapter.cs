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
            return new Address(dto.CustomerId, dto.Street, dto.District, dto.City, dto.State);
        }

        public AddressDto EntityToDto(Address entity)
        {
            return new AddressDto(entity.Street, entity.District, entity.City, entity.State, entity.CustomerId) { Id = entity.Id.GetGuid() };
        }
    }
}
