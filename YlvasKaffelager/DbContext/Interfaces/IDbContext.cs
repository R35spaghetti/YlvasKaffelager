using YlvasKaffelager.Models;

namespace YlvasKaffelager.DbContext.Interfaces;

public interface IDbContext
{
    List<Order> Orders { get; set; }
    public void AddOrder(Order order);
    public Coffee GetCoffee(int id);
}