using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using CustomerWebApi.Infrastructure.Data.Interfaces;

namespace CustomerWebApi.DomainService.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IAddressRepository addressRepository) : base(addressRepository) { }
    }
}
