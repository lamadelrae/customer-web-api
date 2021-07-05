using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Dtos
{
    public class AddressDto : Dto
    {
        public Guid CustomerId { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
