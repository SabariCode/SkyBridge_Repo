using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcWithAngularJS.Controllers;
using MvcWithAngularJS.Models;



namespace MvcWithAngularJs.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]

        public void Login()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Login() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void UserLoginTest()
        {
            DataController _dataController = new DataController();
            var login = new LoginData()
            {
                Username = "Admin",
                Password = "123"
            };
            var result = _dataController.UserLogin(login) as JsonResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void SaveProductTest()
        {
            DataController _dataController = new DataController();
            var product = new ProductData()
            {
                ProductID = 56,
                ProductName = "Kol",
                Availability = 20

            };
            var result = _dataController.SaveProduct(product) as JsonResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Data);
        }

        [TestMethod]

        public void DeleteProductTest()
        {
            DataController _dataController = new DataController();
            var product = new ProductData()
            {
                ProductID = 56,
                ProductName = "Kol",
                Availability = 20

            };
            var result = _dataController.DeleteProduct(product) as JsonResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Data);
        }
        [TestMethod]

        public void GetDataTest()
        {
            DataController _dataController = new DataController();

            var result = _dataController.getData() as JsonResult;

            Assert.IsNotNull(result);
        }
    }
}
