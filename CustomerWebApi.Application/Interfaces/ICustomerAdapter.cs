using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Domain.Models;

namespace CustomerWebApi.Application.Interfaces
{
    public interface ICustomerAdapter : IBaseAdapter<Customer, CustomerDto> { }
}
