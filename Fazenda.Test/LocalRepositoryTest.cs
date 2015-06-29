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
    public class LocalRepositoryTest
    {
        private CustomerContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomerContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CustomerContext();
            var local = ObjectMother.GetLocal();
            _contextForTest.Locais.Add(local);
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateLocalRepositoryTest()
        {
            //Arrange
            Local p = ObjectMother.GetLocal();
            ILocalRepository repository = new LocalRepository();

            //Action
            Local newLocal = repository.Save(p);

            //Assert
            Assert.IsTrue(newLocal.Id > 0);
        }

        [TestMethod]
        public void RetrieveLocalRepositoryTest()
        {
            //Arrange
            ILocalRepository repository = new LocalRepository();

            //Action
            Local local = repository.Get(2);

            //Assert
            Assert.IsNotNull(local);
            Assert.IsTrue(local.Id > 0);
        }


        [TestMethod]
        public void DeleteLocalRepositoryTest()
        {
            //Arrange
            ILocalRepository repository = new LocalRepository();

            //Action
            var deletedLocal = repository.Delete(2);

            //Assert
            var persistedLocal = _contextForTest.Locais.Find(2);
            Assert.IsNull(persistedLocal);

        }

    }
}
