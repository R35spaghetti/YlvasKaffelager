using Microsoft.AspNetCore.Mvc;
using YlvasKaffelager.DbContext;
using YlvasKaffelager.DbContext.Interfaces;
using YlvasKaffelager.Repositories;
using YlvasKaffelager.Repositories.Interfaces;
using YlvasKaffelager.ViewModels;

namespace YlvasKaffelager.Controllers
{
    
    public class OrdersController : Controller
    {   //konstruktionsinjektion
        // [DI] 01 Kontrollern får nu ett objekt för att samtala med databasen
        private readonly IDbContext _dbContext;
        private readonly IProductRepository _productRepository;


        /*[DI] 02 Konstruktorn kommer nu åt databasens interface.
         detta beroende kommer endast köras när kontrollern vill samtala med databasen.
        Nu kan vi enklare testa databasen då beroendet passeras genom konstruktorn. */
        public OrdersController(IDbContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var model = new OrderViewModel();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel model)
        {
            //[Refaktorering] skapa en produkt med hjälp av productRepository
         var coffeeOrder = _productRepository.CreateProductOrder(model);

         return View("ViewOrder", coffeeOrder);
        }

        public IActionResult ViewOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(ViewOrderModel model)
        {
           
          //[Refaktorering] skapar en orderbekräftelse
          var confirmationOrder = _productRepository.CreateReceiptConfirmation(model);
          
            _dbContext.AddOrder(confirmationOrder);

            return View("Completed");
        }

        public IActionResult Completed()
        {
            return View();
        }

    }
}