namespace YlvasKaffelager.ViewModels.Interfaces;

public interface IViewOrderModel 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Brand { get; set; }
    public int Amount { get; set; }
    public decimal Total { get; set; }
}