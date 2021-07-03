using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Dtos
{
    public class CustomerDto : Dto
    {
        public string Name { get; private set; }

        public string Cpf { get; private set; }

        public DateTime BirthDate { get; private set; }

        public List<AddressDto> Addresses { get; private set; } = new List<AddressDto>();

        public CustomerDto(string name,
                           string cpf, 
                           DateTime birthDate)
        {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
        }
    }
}