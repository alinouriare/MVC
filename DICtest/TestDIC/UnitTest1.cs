using DICtest.Controllers;
using DICtest.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;

using Xunit;

namespace TestDIC
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var moq = new Mock<IRepository>();
            moq.SetupGet(c => c.Products).Returns(data);

         
            HomeController homeController = new HomeController(moq.Object);
            //homeController.Repository = moq.Object;

            //act
            Microsoft.AspNetCore.Mvc.ViewResult result = homeController.Index() as ViewResult;

            //assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
