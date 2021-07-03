using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Dtos
{
    public class AddressDto : Dto
    {
        public Guid CustomerId { get; private set; }

        public string Street { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public AddressDto(string street,
                          string district,
                          string city,
                          string state,
                          Guid customerId)
        {
            Street = street;
            District = district;
            City = city;
            State = state;
            CustomerId = customerId;
        }
    }
}
