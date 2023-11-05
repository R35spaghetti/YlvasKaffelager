namespace YlvasKaffelager.Models.Interfaces;

public interface IProduct
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
}