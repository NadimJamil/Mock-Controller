using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mock.depart.Controllers;
using mock.depart.Models;
using mock.depart.Services;
using Moq;
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
        [TestMethod()]
        public void deleteNonExistantCat()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(serviceMock.Object) { CallBase = true };
            serviceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(value: null);
            controller.Setup(s => s.UserId).Returns("1");
            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as NotFoundResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ownerIdPasMemeQueUserId()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(serviceMock.Object) { CallBase = true };

            CatOwner catOwner = new CatOwner()
            {
                Id = "31"
            };
            Cat chat = new Cat()
            {
                Id = 1,
                Name = "Max",
                CatOwner = catOwner,
                CuteLevel = Cuteness.Amazing
            };

            serviceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(value: null);
            controller.Setup(s => s.UserId).Returns("1");
            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.AreEqual("Ce n'est pas ton chat.", result.Value);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void tropCute()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(serviceMock.Object) { CallBase = true };

            CatOwner catOwner = new CatOwner()
            {
                Id = "1"
            };
            Cat chat = new Cat()
            {
                Id = 1,
                Name = "Max",
                CatOwner = catOwner,
                CuteLevel = Cuteness.Amazing
            };

            serviceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(value: null);
            controller.Setup(s => s.UserId).Returns("1");
            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.AreEqual("Le chat est trop cute.", result.Value);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void deleteCatTest()
        {

            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(serviceMock.Object) { CallBase = true };

            CatOwner catOwner = new CatOwner()
            {
                Id = "1"
            };
            Cat chat = new Cat()
            {
                Id = 1,
                Name = "Max",
                CatOwner = catOwner,
                CuteLevel = Cuteness.Amazing
            };

            serviceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(value: null);
            controller.Setup(s => s.UserId).Returns("1");
            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as BadRequestObjectResult;

            var chatSupp = (Cat?)result!.Value;
            Assert.AreEqual(chat.Id, chatSupp.Id);
            Assert.IsNotNull(result);
        }
    }
}