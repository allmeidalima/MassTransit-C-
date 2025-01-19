using MassTransit.Application.Contracts.Enum;

namespace MassTransit.Application.Contracts;

public class ProductCreateEvent
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ECategories Category { get; set; }
    public long Ean { get; set; }
}