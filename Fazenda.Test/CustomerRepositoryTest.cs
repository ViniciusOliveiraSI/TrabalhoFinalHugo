using Fazenda.Domain;
using Fazenda.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private CustomerContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CustomerContext();

            var customer = ObjectMother.GetCustomer();

            _contextForTest.Customers.Add(customer);

            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateCustomerRepositoryTest()
        {
            //Arrange
            Customer b = ObjectMother.GetCustomer();
            ICustomerRepository repository = new CustomerRepository();

            //Action
            Customer newCustomer = repository.Save(b);

            //Assert
            Assert.IsTrue(newCustomer.Id > 0);
            Assert.IsTrue(newCustomer.Locais[0].Id > 0);
        }

        [TestMethod]
        public void RetrieveCustomerRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();

            //Action
            Customer customer = repository.Get(1);

            //Assert
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(customer.Nome));
            Assert.IsFalse(string.IsNullOrEmpty(customer.Telefone));
            Assert.IsFalse(string.IsNullOrEmpty(customer.Endereco));

        }

        [TestMethod]
        public void UpdateCustomerRepositoryTest()
        {
            //Arrange
            ICustomerRepository repository = new CustomerRepository();
            Customer customer = _contextForTest.Customers.Find(2);
            customer.Nome = "Vinicius";
            customer.Telefone = "4999517803";
            customer.Endereco = "Joao Severiano Waltrick";

            //Action
            var updatedCustomer = repository.Update(customer);

            //Assert
            var persistedCustomer = _contextForTest.Customers.Find(2);
            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(updatedCustomer.Id, persistedCustomer.Id);
            Assert.AreEqual(updatedCustomer.Nome, persistedCustomer.Nome);
            Assert.AreEqual(updatedCustomer.Telefone, persistedCustomer.Telefone);
            Assert.AreEqual(updatedCustomer.Endereco, persistedCustomer.Endereco);

        }


    }
}
