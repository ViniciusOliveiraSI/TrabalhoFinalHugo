using Fazenda.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Test
{
    [TestClass]
    public class LocalDomainTest
    {
        [TestMethod]
        public void CreateALocalTest()
        {
            Local local = ObjectMother.GetLocal();

            Assert.IsNotNull(local);
        }

        [TestMethod]
        public void CreateAValidLocalTest()
        {
            Local local = ObjectMother.GetLocal();

            //Validator.Validate(local);
        }

        
    }
}
