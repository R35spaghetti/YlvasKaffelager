using YlvasKaffelager.Models.Interfaces;

namespace YlvasKaffelager.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
