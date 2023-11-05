namespace YlvasKaffelager.Models.Interfaces;

public interface IOrder
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Brand { get; set; }
    public int Amount { get; set; }
    public decimal Total { get; set; }
}