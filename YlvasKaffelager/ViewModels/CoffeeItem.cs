using YlvasKaffelager.ViewModels.Interfaces;

namespace YlvasKaffelager.ViewModels;

    public class CoffeeItem : IProductItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
