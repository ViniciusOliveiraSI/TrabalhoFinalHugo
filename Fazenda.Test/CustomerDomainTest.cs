using Fazenda.Domain;
using Fazenda.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Test
{
    [TestClass]
    public class CustomerDomainTest
    {
        [TestMethod]
        public void CreateACustomerTest()
        {
            Customer customer = ObjectMother.GetCustomer();

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void CreateAValidCustomerTest()
        {
            Customer customer = ObjectMother.GetCustomer();

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerNameTest()
        {
            Customer customer = new Customer();

            Validator.Validate(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCustomerPhoneTest()
        {
            Customer customer = new Customer();
            customer.Nome = "Vinicius";

            Validator.Validate(customer);
        }
    }
}
