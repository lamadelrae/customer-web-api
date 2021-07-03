using CustomerWebApi.Application.Dtos;
using CustomerWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Interfaces
{
    public interface IAddressAdapter : IBaseAdapter<Address, AddressDto> { }
}
