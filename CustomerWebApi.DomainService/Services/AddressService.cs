using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using CustomerWebApi.Infrastructure.Data.Interfaces;

namespace CustomerWebApi.DomainService.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IAddressRepository addressRepository) : base(addressRepository) { }

        public override Address Insert(Address obj)
        {
            obj.IsAddressValid();
            _baseRepository.Insert(obj);
            return obj;
        }

        public override Address Update(Address obj)
        {
            obj.IsAddressValid();
            _baseRepository.Update(obj);
            return obj;
        }
    }
}
