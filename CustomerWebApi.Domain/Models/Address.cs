using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerWebApi.Infrastructure.CrossCutting;

namespace CustomerWebApi.Domain.Models
{
    public class Address : Entity
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Customer Customer { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; private set; }

        [Required]
        [MaxLength(40)]
        public string District { get; private set; }

        [Required]
        [MaxLength(40)]
        public string City { get; private set; }

        [Required]
        [MaxLength(40)]
        public string State { get; private set; }

        private Address() { }

        public Address(Guid customerId,
                       string street,
                       string district,
                       string city,
                       string state)
        {

            CustomerId = customerId;
            Street = street;
            District = district;
            City = city;
            State = state;
        }

        public Address(Guid id,
                       Guid customerId,
                       string street,
                       string district,
                       string city,
                       string state)
        {

            Id = id;
            CustomerId = customerId;
            Street = street;
            District = district;
            City = city;
            State = state;
        }

        public void SetCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void IsAddressValid()
        {
            this.IsValid();
        }
    }
}
