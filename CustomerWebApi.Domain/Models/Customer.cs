using CustomerWebApi.Infrastructure.CrossCutting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Domain.Models
{
    public class Customer : Entity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; private set; }

        [Required]
        public string Cpf { get; private set; }

        [Required]
        public DateTime BirthDate { get; private set; }

        public List<Address> Addresses { get; private set; } = new List<Address>();

        public int Age
        {
            get
            {
                return DateTime.Today.Year - BirthDate.Year;
            }
        }

        private Customer() { }

        public Customer(string name,
                        string cpf,
                        DateTime birthDate)
        {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            IsCustomerValid();
        }

        public Customer(Guid id, 
                        string name,
                        string cpf,
                        DateTime birthDate)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            IsCustomerValid();
        }

        public void IsCustomerValid()
        {
            if (!IsCpfValid())
                throw new ArgumentException("Invalid CPF!");

            this.IsValid();
        }

        public bool IsCpfValid()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");
            if (Cpf.Length != 11)
                return false;
            tempCpf = Cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return Cpf.EndsWith(digito);
        }
    }
}
