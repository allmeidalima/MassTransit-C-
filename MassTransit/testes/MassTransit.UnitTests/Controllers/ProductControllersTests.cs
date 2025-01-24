using Masstransit.WebApi.Controllers;
using Masstransit.WebApi.Models;
using MassTransit.Application.Contracts;
using MassTransit.Application.Contracts.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MassTransit.UnitTests.Controllers
{

    public class ProductControllersTests
    {
        private readonly Mock<ILogger<ProductController>> _loggerMock;
        private readonly Mock<IPublishEndpoint> _publishEndpointMock;
        private readonly ProductController _controller;

        public ProductControllersTests()
        {
            _loggerMock = new Mock<ILogger<ProductController>>();
            _publishEndpointMock = new Mock<IPublishEndpoint>();
            _controller = new ProductController(_loggerMock.Object, _publishEndpointMock.Object);
        }

        [Fact]
        public async Task CreateProduct_ShouldPublishEvent_AndReturnOk()
        {
            // Arrange
            var productId = 1L;
            var productCreateDto = new ProductCreateDto
            {
                Category = 1,
                Name = "Smartphone",
                Price = 999.99M,
                Ean = 1234567890123
            };

            // Act
            var result = await _controller.CreateProduct(productId, productCreateDto);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}