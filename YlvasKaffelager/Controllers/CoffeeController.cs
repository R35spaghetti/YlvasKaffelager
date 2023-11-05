using Microsoft.AspNetCore.Mvc;

namespace YlvasKaffelager.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult KaffeUtbud()
        {
            return View();
        }
    }
}
