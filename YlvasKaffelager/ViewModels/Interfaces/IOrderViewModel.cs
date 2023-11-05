namespace YlvasKaffelager.ViewModels.Interfaces;

public interface IOrderViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int CoffeeId { get; set; }
    public int Amount { get; set; }
    public List<CoffeeItem> CoffeeItems { get; set; }
}