using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MassTransit.Application.Contracts.Handlers;

public class ProductStockHandler: IConsumer<ProductCreateEvent>
{
    private readonly ILogger<ProductStockHandler> _logger;
    public ProductStockHandler(ILogger<ProductStockHandler> logger)
    {
        _logger=logger;
    }
    public async Task Consume(ConsumeContext<ProductCreateEvent> context)
    {
        _logger.LogInformation("Received message: {@Message}", context.Message);
        Console.WriteLine($"NotificationCreated event consumed. Message: {context.Message}");
    }
}