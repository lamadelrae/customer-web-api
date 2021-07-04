using CustomerWebApi.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Tests
{
    public class AddressTests
    {
        #region PropertyTests

        [Test]
        public void NoGuid()
        {
            try
            {
                Address address = new Address(Guid.Empty, "A", "A", "A", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoStreet()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), string.Empty, "A", "A", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoDistrict()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "AAA", string.Empty, "A", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoCity()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "AAA", "A", string.Empty, "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoState()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "A", "A", "A", string.Empty);
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        #endregion

        #region OverFlowTests
        [Test]
        public void StreetOverFlow()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "SADASDLKJASDLKASDJKLASDJADLSKJASDKLASDJKLASDJALSDKJADSLKJADSLKADSJKLASDJADSLKJADSKLADJSKLASDJ", "A", "A", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void DistrictOverFlow()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "A", "SADOIJADSOIJASDKLASDJKLASDKJLASDJKLJKASDLJKLASDJKLASDJKLASDDASDKLASJASDKLDASJKLASDJAKLSDJ", "A", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CityOverFlow()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "A", "A", "SADOIJADSOIJASDKLASDJKLASDKJLASDJKLJKASDLJKLASDJKLASDJKLASDDASDKLASJASDKLDASJKLASDJAKLSDJ", "A");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void StateOverFlow()
        {
            try
            {
                Address address = new Address(Guid.NewGuid(), "A", "A", "A", "SADOIJADSOIJASDKLASDJKLASDKJLASDJKLJKASDLJKLASDJKLASDJKLASDDASDKLASJASDKLDASJKLASDJAKLSDJ");
                address.IsAddressValid();
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        #endregion
    }
}