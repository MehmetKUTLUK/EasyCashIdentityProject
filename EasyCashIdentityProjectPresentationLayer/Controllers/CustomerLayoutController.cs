using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
