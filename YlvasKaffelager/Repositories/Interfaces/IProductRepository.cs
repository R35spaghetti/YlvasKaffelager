using YlvasKaffelager.Models;
using YlvasKaffelager.ViewModels;

namespace YlvasKaffelager.Repositories.Interfaces;

public interface IProductRepository
{
    //[03-LC] Allt med ordrar är en beräkning i OrderController, det plockas ut läggs i (I)ProductRepository
    public ViewOrderModel CreateProductOrder(OrderViewModel model);
    public Order CreateReceiptConfirmation(ViewOrderModel model);


    public int GetNextOrder(int currentOrder);

}