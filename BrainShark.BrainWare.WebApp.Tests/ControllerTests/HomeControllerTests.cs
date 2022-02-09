using System.Web.Mvc;
using BrainShark.BrainWare.WebApp.Controllers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainShark.BrainWare.WebApp.Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Should_set_title_when_requesting_home_page()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            ((string)result.ViewBag.Title).Should().Be("Home Page");
        }
    }
}