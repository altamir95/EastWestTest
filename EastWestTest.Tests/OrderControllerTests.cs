using EastWestTest.Controllers;
using EastWestTest.Domain.Core;
using EastWestTest.Domain.Interfaces;
using EastWestTest.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EastWestTest.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void APIGetOneOrderReturnTrueIfEqualOrderedProductsCounts()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetOrder(1)).Returns(GetTestUser());
            var mockOrder = new Mock<IOrderFilter>();
            var controller = new OrderController(mockRepo.Object, mockOrder.Object);
            // Act
            var result = controller.Get(1);
            // Assert
            Assert.Equal(GetTestUser().OrderedProducts.Count, result.Value.OrderedProducts.Count);
        }

        [Fact]
        public void APIGetOrderListReturnTrueIfEqualCounts()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetOrderList()).Returns(GetTestUsers());
            var mockOrder = new Mock<IOrderFilter>();
            var controller = new OrderController(mockRepo.Object, mockOrder.Object);
            // Act
            var result = controller.Get();
            // Assert
            Assert.Equal(GetTestUsers().Count, result.Value.ToList().Count);
        }


        private List<Order> GetTestUsers()
        {
            var orders = new List<Order>
            {
                new Order { OrderId=1, CustomerId=1, Customer= new Customer(){CustomerId=1,  Name = "Jhon"}, DateTime = new DateTime(2015, 7, 20), OrderedProducts= new List<OrderedProduct>(){new OrderedProduct {OrderedProductId=1, OrderId = 1,  ProductId = 1 , Product= new Product { ProductId=1, Name = "Cadbury Dairy Milk" } } }},
                new Order { OrderId=2,CustomerId=2, Customer= new Customer(){CustomerId=2,  Name = "Alex"}, DateTime = new DateTime(2016, 7, 20), OrderedProducts= new List<OrderedProduct>(){new OrderedProduct {OrderedProductId=2, OrderId = 2, ProductId = 2, Product= new Product { ProductId=2, Name = "Hershey's Cookies & Cream" } } }},
                new Order { OrderId=3,CustomerId=3, Customer= new Customer(){CustomerId=3,  Name = "Harry"}, DateTime = new DateTime(2017, 7, 20), OrderedProducts= new List<OrderedProduct>(){new OrderedProduct {OrderedProductId=3, OrderId = 3, ProductId = 3, Product = new Product { ProductId = 3, Name = "Snickers" } } }},
                new Order { OrderId=4,CustomerId=4, Customer= new Customer(){CustomerId=4,  Name = "Oliver"}, DateTime = new DateTime(2018, 7, 20), OrderedProducts= new List<OrderedProduct>(){new OrderedProduct {OrderedProductId=4, OrderId = 4, ProductId = 4, Product = new Product { ProductId = 4, Name = "Bounty" } } }},
            };
            return orders;
        }
        private Order GetTestUser()
        {
            return new Order { OrderId = 1, CustomerId = 1, Customer = new Customer() { CustomerId = 1, Name = "Jhon" }, DateTime = new DateTime(2015, 7, 20), OrderedProducts = new List<OrderedProduct>() { new OrderedProduct { OrderedProductId = 1, OrderId = 1, ProductId = 1, Product = new Product { ProductId = 1, Name = "Cadbury Dairy Milk" } } } };
        }
    }
}
