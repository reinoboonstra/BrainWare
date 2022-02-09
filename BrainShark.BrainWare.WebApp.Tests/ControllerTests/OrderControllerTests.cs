using System.Collections.Generic;
using System.Linq;
using BrainShark.BrainWare.WebApp.Controllers.API;
using BrainShark.BrainWare.WebApp.Infrastructure.Services;
using BrainShark.BrainWare.WebApp.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BrainShark.BrainWare.WebApp.Tests.ControllerTests
{
    [TestClass]
    public class OrderControllerTests
    {
        private Mock<IOrderService> _orderServiceMock;
        private OrderController _orderController;

        [TestInitialize]
        public void Initialize()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _orderController = new OrderController(_orderServiceMock.Object);
        }

        [TestMethod]
        public void Should_return_empty_list_if_no_orders_found()
        {
            // Arrange
            const int companyId = 3;

            // Act
            var result = _orderController.GetOrders(companyId);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void Should_return_list_of_orders_when_orders_are_found()
        {
            // Arrange
            const int companyId = 4;

            _orderServiceMock.Setup(x => x.GetForCompany(companyId)).Returns(new List<Order>
            {
                new Order(),
                new Order()
            });

            // Act
            var result = _orderController.GetOrders(companyId);

            // Assert
            result.Count().Should().Be(2);
        }

        [TestMethod]
        public void Should_return_order_with_correct_details()
        {
            // Arrange
            const int companyId = 5;

            _orderServiceMock.Setup(x => x.GetForCompany(companyId)).Returns(new List<Order>
            {
                new Order
                {
                    CompanyName = "Test company",
                    Description = "Test description",
                    OrderId = 2,
                    OrderProducts = new List<OrderProduct>
                    {
                        new OrderProduct
                        {
                            OrderId = 2,
                            Price = 10,
                            Product = new Product
                            {
                                Price = 10,
                                Name = "Test product"
                            },
                            ProductId = 6,
                            Quantity = 2
                        }
                    },
                    OrderTotal = 20
                }
            });

            // Act
            var result = _orderController.GetOrders(companyId);

            // Assert
            result.Count().Should().Be(1);
            var order = result.First();
            order.CompanyName.Should().Be("Test company");
            order.Description.Should().Be("Test description");
            order.OrderId.Should().Be(2);
            order.OrderTotal.Should().Be(20);
            var orderProduct = order.OrderProducts.First();
            orderProduct.OrderId.Should().Be(2);
            orderProduct.Price.Should().Be(10);
            orderProduct.Quantity.Should().Be(2);
            orderProduct.Product.Price.Should().Be(10);
            orderProduct.Product.Name.Should().Be("Test product");
        }
    }
}
