using Microsoft.VisualStudio.TestTools.UnitTesting;
using mock.depart.Controllers;
using mock.depart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.depart.Controllers.Tests
{
    [TestClass()]
    public class CatsControllerTests
    {
        protected Cat nvChat1, nvChat2, nvChat3;
        protected CatOwner catOwner;

        protected void Init()
        {
            nvChat1 = new Cat()
            {
                Id = 1,
                Name = "bob",
                CuteLevel = Cuteness.BarelyOk

            };

            nvChat2 = new Cat()
            {
                Id = 2,
                Name = "max",
                CuteLevel = Cuteness.YouCanKeepIt

            };

            nvChat3 = new Cat()
            {
                Id = 3,
                Name = "gar",
                CuteLevel = Cuteness.Amazing

            };

            catOwner = new CatOwner
            {
                Id = "1"
            };
        }

        [TestMethod()]
        public void deleteNonExistantCat()
        {
            Assert.Equals(null, cat.Id);
        }

        [TestMethod()]
        public void ownerIdPasMemeQueUserId()
        {
            Assert.Equals(null, cat.Id);
        }

        [TestMethod()]
        public void pasAssezCute()
        {
            Assert.Equals(null, cat.Id);
        }

        [TestMethod()]
        public void deleteCatTest()
        {

            Assert.AreEqual(3, nvChat3.Id);
            Assert.AreEqual(Cuteness.Amazing, nvChat3.CuteLevel);
            Assert.AreEqual(3, nvChat3.Id);
        }
    }
}