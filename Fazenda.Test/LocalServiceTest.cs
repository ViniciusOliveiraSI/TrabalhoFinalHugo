using Fazenda.Aplicattion;
using Fazenda.Domain;
using Fazenda.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Test
{
    [TestClass]
    public class AccommodationServiceTest
    {

        [TestMethod]
        public void CreateLocalServiceValidationAndPersistenceTest()
        {
            //Arrange
            Local local = ObjectMother.GetLocal();
            //Fake do repositório
            var repositoryFake = new Mock<ILocalRepository>();
            repositoryFake.Setup(r => r.Save(local)).Returns(local);
            //Fake do dominio
            var localFake = new Mock<Local>();
            localFake.As<IObjectValidation>().Setup(b => b.Validate());

            ILocalService service = new LocalService(repositoryFake.Object);

            //Action
            service.Create(localFake.Object);

            //Assert
            localFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(localFake.Object));
        }

        [TestMethod]
        public void RetrieveLocalServiceTest()
        {
            //Arrange
            Local local = ObjectMother.GetLocal();
            //Fake do repositório
            var repositoryFake = new Mock<ILocalRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(local);

            ILocalService service = new LocalService(repositoryFake.Object);

            //Action
            var localFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(localFake);
        }

        [TestMethod]
        public void UpdateLocalServiceValidationAndPersistenceTest()
        {
            //Arrange
            Local local = ObjectMother.GetLocal();
            //Fake do repositório
            var repositoryFake = new Mock<ILocalRepository>();
            repositoryFake.Setup(r => r.Update(local)).Returns(local);
            //Fake do dominio
            var localFake = new Mock<Local>();
            localFake.As<IObjectValidation>().Setup(b => b.Validate());

            ILocalService service = new LocalService(repositoryFake.Object);

            //Action
            service.Update(localFake.Object);

            //Assert
            localFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(localFake.Object));
        }

        [TestMethod]
        public void DeleteLocalServiceTest()
        {
            //Arrange
            Local local = null;
            //Fake do repositório
            var repositoryFake = new Mock<ILocalRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(local);

            ILocalService service = new LocalService(repositoryFake.Object);

            //Action
            var localFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(localFake);
        }
    }
}
