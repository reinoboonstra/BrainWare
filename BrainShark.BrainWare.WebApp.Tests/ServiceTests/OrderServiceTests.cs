using System.Data;
using System.Linq;
using BrainShark.BrainWare.WebApp.Infrastructure.Database;
using BrainShark.BrainWare.WebApp.Infrastructure.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BrainShark.BrainWare.WebApp.Tests.ServiceTests
{
    [TestClass]
    public class OrderServiceTests
    {
        private Mock<IDatabase> _databaseMock;
        private IOrderService _orderService;

        [TestInitialize]
        public void Initialize()
        {
            _databaseMock = new Mock<IDatabase>();
            _orderService = new OrderService(_databaseMock.Object);
        }

        [TestMethod]
        public void Should_return_empty_if_no_orders_found()
        {
            // Arrange
            const int companyId = 3;
            var dataReaderMock = new Mock<IDataReader>();
            _databaseMock.Setup(x => x.ExecuteReader(It.IsAny<string>())).Returns(dataReaderMock.Object);

            // Act
            var result = _orderService.GetForCompany(companyId);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void Should_return_an_order_when_order_is_found()
        {
            // Arrange
            const int companyId = 7;

            var dataReaderMock = new Mock<IDataReader>();
            dataReaderMock.Setup(m => m.FieldCount).Returns(2);
            dataReaderMock.Setup(m => m.GetString(0)).Returns("Company 7");
            
            dataReaderMock.SetupSequence(m => m.Read())
                .Returns(true)
                .Returns(false);

            _databaseMock.Setup(x => x.ExecuteReader(It.IsAny<string>())).Returns(dataReaderMock.Object);

            // Act
            var result = _orderService.GetForCompany(companyId);

            // Assert
            result.Count().Should().Be(1);
        }
    }
}