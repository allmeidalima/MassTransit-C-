using MassTransit;
using Microsoft.Extensions.Logging;
using System;

namespace MassTransit.Application.Contracts.Handlers;

public class ProductStockHandler: IConsumer<ProductCreateEvent>
{
    private readonly ILogger<ProductStockHandler> _logger;
    public ProductStockHandler(ILogger<ProductStockHandler> logger)
    {
        _logger=logger;
    }
    public Task Consume(ConsumeContext<ProductCreateEvent> context)
    {
          return Task.CompletedTask;
    }
}