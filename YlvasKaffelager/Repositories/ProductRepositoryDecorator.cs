using YlvasKaffelager.Models;
using YlvasKaffelager.Repositories.Interfaces;
using YlvasKaffelager.ViewModels;

namespace YlvasKaffelager.Repositories;

public class ProductRepositoryDecorator : IProductRepository
{
    private readonly IProductRepository? _productRepository;
    private List<ViewOrderModel> SavedReciepts { get; set; } //Sparar ordrar/kvitton på beställningar

    //Ctor
    public ProductRepositoryDecorator(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    public ViewOrderModel CreateProductOrder(OrderViewModel model)
    {
        var viewOrderModel = _productRepository?.CreateProductOrder(model);
        return viewOrderModel;
    }

    public Order CreateReceiptConfirmation(ViewOrderModel model)
    {
        var viewOrderModel = _productRepository?.CreateReceiptConfirmation(model);
        SavedReciepts.Add(model);     //Kvitton som går igenom ska kunna sparas.
        return viewOrderModel;

    }

    public int GetNextOrder(int currentOrder)
    {
        currentOrder = _productRepository.GetNextOrder(currentOrder);

        return currentOrder;
    }

  
}

