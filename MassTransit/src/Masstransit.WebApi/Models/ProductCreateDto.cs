namespace Masstransit.WebApi.Models;
public class ProductCreateDto
{
    public long Id { get; set; }
    public string Name { get; set; }  = string.Empty;
    public decimal Price { get; set; }
    public int Category { get; set; }
    public long Ean { get; set; }
}