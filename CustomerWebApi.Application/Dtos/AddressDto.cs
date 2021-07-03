using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Dtos
{
    public class AddressDto : Dto
    {
        public CustomerDto Customer { get; private set; }

        public string Street { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public AddressDto(string street,
                          string district,
                          string city,
                          string state,
                          CustomerDto customer)
        {
            Street = street;
            District = district;
            City = city;
            State = state;
            Customer = customer;
        }
    }
}
