using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Dtos
{
    public class CustomerDto : Dto
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}