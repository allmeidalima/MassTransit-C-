using Masstransit.WebApi.Models;
using MassTransit;
using MassTransit.Application.Contracts;
using MassTransit.Application.Contracts.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Masstransit.WebApi.Controllers
{
    [Route("api/[controller]")] // api/product
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly ILogger<ProductController> _logger;
        private readonly IPublishEndpoint _publish;

        public ProductController(ILogger<ProductController> logger, IPublishEndpoint publish)
        {
            _logger = logger;
            _publish = publish;
        }

        [HttpPost(Name = "create-product/{productId}")] // api/product/createproduct
        public IActionResult CreateProduct([FromRoute] long productId, [FromBody] ProductCreateDto productCreateDto)
        {
            _ = _publish.Publish<ProductCreateEvent>(new
            {
                id = productId,
                Category = productCreateDto.Category,
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Ean = productCreateDto.Ean
            }); 

            return Ok();
        }

    }
}