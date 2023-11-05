using YlvasKaffelager.DbContext;
using YlvasKaffelager.DbContext.Interfaces;
using YlvasKaffelager.Models;
using YlvasKaffelager.Repositories.Interfaces;
using YlvasKaffelager.ViewModels;

namespace YlvasKaffelager.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _dbContext;
        private int NumberOfOrders { get; set; }
        public ProductRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ViewOrderModel CreateProductOrder(OrderViewModel model)
        {
            var coffee = _dbContext.GetCoffee(model.CoffeeId);

            var order = new ViewOrderModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Brand = coffee.Brand,
                Amount = model.Amount,
                Total = (model.Amount * coffee.Price)
            };
            return order;

        }
        
        public Order CreateReceiptConfirmation(ViewOrderModel model)
        {
            NumberOfOrders++;
            var reciept = new Order
            {
                Id = NumberOfOrders,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Brand = model.Brand,
                Amount = model.Amount,
                Total = model.Total,
            };

            return reciept;
        }

        //Totalt onödig likt NumberOfOrders, då vi inte jobbar med en databas som skulle ha fixat Id:et åt oss.
        public int GetNextOrder(int currentOrder)
        {
            return currentOrder; //Tanken var att öka id:et vid varje beställning, men det behövs inte.
        }
    }
}