using CustomerWebApi.Domain.Models;
using NUnit.Framework;
using System;

namespace CustomerWebApi.Test
{
    public class CustomerTests
    {
        [Test]
        public void NoName()
        {
            try
            {
                Customer customer = new Customer(string.Empty, "34024118579", DateTime.Now);
                customer.IsCustomerValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoCpf()
        {
            try
            {
                Customer customer = new Customer("Matthew", string.Empty, DateTime.Now);
                customer.IsCustomerValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void UnValidCpf()
        {
            try
            {
                Customer customer = new Customer("Matthew", "123456789", DateTime.Now);
                customer.IsCustomerValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void UnValidLength()
        {
            try
            {
                Customer customer = new Customer("3290832903829038290328902382390", "120982190128129081209128", DateTime.Now);
                customer.IsCustomerValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
    }
}